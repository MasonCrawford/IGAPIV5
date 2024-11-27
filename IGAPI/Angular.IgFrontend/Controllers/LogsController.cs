using Common;
using Data.Dto;
using DataFactory.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Angular.IgFrontend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogsController : ControllerBase
{
    private readonly ILogger<TradingTargetController> _logger;
    private readonly ILoggerDataService _loggerDataService;
    private readonly IUriService _uriService;

    public LogsController(ILoggerDataService loggerDataService, IUriService uriService, ILogger<TradingTargetController> logger)
    {
        _loggerDataService = loggerDataService;
        _uriService = uriService;

        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]ApiPaginationFilter filter)
    {
        var route = Request.Path.Value;
        var validFilter = new ApiPaginationFilter(filter.PageNumber, filter.PageSize);

        var pagedData =  _loggerDataService.GetAll(filter.PageNumber,filter.PageSize);
        var totalRecords = _loggerDataService.Count();
        var pagedReponse = PaginationHelper.CreatePagedReponse<LogDto>(pagedData.ToList(), validFilter, totalRecords, _uriService, route);
        return Ok(pagedReponse);
    }

    [HttpGet("{logLevel}")]
    public async Task<IEnumerable<LogDto>> Get(LogLevel logLevel, string? category = null)
    {
        if (category == null) return _loggerDataService.Get(logLevel);

        return _loggerDataService.Get(logLevel, category);
    }

    [HttpGet("Categories")]
    public async Task<IEnumerable<string>> Categories()
    {
        return _loggerDataService.Categories();
    }
}