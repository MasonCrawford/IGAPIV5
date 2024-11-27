using System.Net.Http.Headers;

namespace IgClient.Interfaces;

public interface IIgRestService
{
    void ParseHeaders(ConversationContext conversationContext, HttpResponseHeaders headers);
    void SetDefaultRequestHeaders(HttpClient client, ConversationContext conversationContext, string version);

    Task RestfulService(string uri, HttpMethod method, string version,
        ConversationContext conversationContext, object bodyInput = null);

    Task<IgResponse<T>> RestfulService<T>(string uri, HttpMethod method, string version,
        ConversationContext conversationContext, object bodyInput = null);
}