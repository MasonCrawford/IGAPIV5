﻿using System.Net;
using System.Net.Http.Headers;
using IgClient.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;

namespace IgClient;

public class IgRestService : IIgRestService
{
    private static string _baseUrl = "https://demo-api.ig.com";
    private readonly ILogger<IgRestService> _logger;

    public IgRestService(ILogger<IgRestService> logger, IConfiguration configuration)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        var env = configuration["ApiEnvironment"];
        _baseUrl = $"https://{(env == "live" ? "" : env + "-")}api.ig.com";
    }

    public void ParseHeaders(ConversationContext conversationContext, HttpResponseHeaders headers)
    {
        if (conversationContext != null)
            foreach (var header in headers)
            {
                if (header.Key == "CST") conversationContext.cst = header.Value.First();
                if (header.Key.Equals("X-SECURITY-TOKEN"))
                    conversationContext.xSecurityToken = header.Value.First();
                if (header.Key == "authorization") conversationContext.oauthToken = header.Value.First();
                if (header.Key.Equals("IG-ACCOUNT-ID")) conversationContext.accountId = header.Value.First();
            }
    }

    public void SetDefaultRequestHeaders(HttpClient client, ConversationContext conversationContext, string version)
    {
        if (conversationContext != null)
        {
            if (conversationContext.apiKey != null)
                client.DefaultRequestHeaders.Add("X-IG-API-KEY", conversationContext.apiKey);
            if (conversationContext.cst != null) client.DefaultRequestHeaders.Add("CST", conversationContext.cst);
            if (conversationContext.xSecurityToken != null)
                client.DefaultRequestHeaders.Add("X-SECURITY-TOKEN", conversationContext.xSecurityToken);
            if (conversationContext.oauthToken != null)
                client.DefaultRequestHeaders.Add("authorization", $"Bearer {conversationContext.oauthToken}");
            if (conversationContext.accountId != null)
                client.DefaultRequestHeaders.Add("IG-ACCOUNT-ID", conversationContext.accountId);
            client.DefaultRequestHeaders.Add("VERSION", version);
        }
        //This only works for version 1 !!!           
        //client.DefaultRequestHeaders.TryAddWithoutValidation("version", version ?? "1");
    }

    public async Task RestfulService(string uri, HttpMethod method, string version,
        ConversationContext conversationContext, object bodyInput = null)
    {
        StringContent scontent;

        if (bodyInput != null)
        {
            scontent = new StringContent(JsonConvert.SerializeObject(bodyInput));
            scontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
        else
        {
            scontent = null;
        }

        var client = new HttpClient();
        var response = new HttpResponseMessage();

        SetDefaultRequestHeaders(client, conversationContext, version);

        switch (method.Method)
        {
            case "POST":
                var postTask = client.PostAsync(_baseUrl + uri, scontent);
                response = postTask.Result;
                break;

            case "GET":
                var getTask = client.GetAsync(_baseUrl + uri);
                response = getTask.Result;
                break;

            case "PUT":
                var putTask = client.PutAsync(_baseUrl + uri, scontent);
                response = putTask.Result;
                break;

            case "DELETE":
                var deleteTask = client.DeleteAsync(_baseUrl + uri);
                response = deleteTask.Result;
                break;
        }

        if (response != null)
        {
            ParseHeaders(conversationContext, response.Headers);
            await response.Content.ReadAsStringAsync();
        }
    }

    public async Task<IgResponse<T>> RestfulService<T>(string uri, HttpMethod method, string version,
        ConversationContext conversationContext, object bodyInput = null)
    {
        StringContent scontent;

        var localVar = new IgResponse<T> {Response = default, StatusCode = HttpStatusCode.OK};

        if (bodyInput != null)
        {
            scontent = new StringContent(JsonConvert.SerializeObject(bodyInput));
            scontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
        else
        {
            scontent = null;
        }

        var client = new HttpClient();
        SetDefaultRequestHeaders(client, conversationContext, version);

        var response = new HttpResponseMessage();

        string content = null;

        switch (method.Method)
        {
            case "POST":
                var myPostTask = client.PostAsync(_baseUrl + uri, scontent);
                response = myPostTask.Result;
                break;

            case "GET":
                var myGetTask = client.GetAsync(_baseUrl + uri);
                response = myGetTask.Result;
                break;

            case "PUT":
                var myPutTask = client.PutAsync(_baseUrl + uri, scontent);
                response = myPutTask.Result;
                break;

            case "DELETE":
                Task<HttpResponseMessage> myDeleteTask;

                if (scontent != null)
                {
                    scontent.Headers.Add("_method", "DELETE");
                    myDeleteTask = client.PostAsync(_baseUrl + uri, scontent);
                }
                else
                {
                    myDeleteTask = client.DeleteAsync(_baseUrl + uri);
                }

                response = myDeleteTask.Result;
                break;
        }

        if (response != null)
        {
            ParseHeaders(conversationContext, response.Headers);
            localVar.StatusCode = response.StatusCode;
            _logger.LogInformation(method.Method + " request to " + _baseUrl + uri + " returned status " +
                                   localVar.StatusCode);

            content = await response.Content.ReadAsStringAsync();
        }

        if (content != null)
        {
            var jss = new JsonSerializerSettings();
            jss.Converters.Add(new StringEnumConverter());
            jss.MissingMemberHandling = MissingMemberHandling.Ignore;
            jss.FloatFormatHandling = FloatFormatHandling.String;
            jss.NullValueHandling = NullValueHandling.Ignore;
            jss.Error += DeserializationError;
            client.Dispose();

            try
            {
                var json = JsonConvert.DeserializeObject<T>(content, jss);
                if (localVar.StatusCode == HttpStatusCode.OK)
                    localVar.Response = json;
                else
                    _logger.LogError(method.Method + " request to " + _baseUrl + uri + " returned " + content);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        return localVar;
    }

    private static void DeserializationError(object sender, ErrorEventArgs eventArgs)
    {
        eventArgs.ErrorContext.Handled = true;
    }
}