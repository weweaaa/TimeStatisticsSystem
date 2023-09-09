using Microsoft.AspNetCore.Mvc;
using TimeStatisticsSystem.Models.DayWork;
using TimeStatisticsSystem.Services;

namespace TimeStatisticsSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class DayWorkController : ControllerBase
{
    private readonly ILogger<DayWorkController> _logger;
    private IWorkInfoService _workInfoService;

    public DayWorkController(
        ILogger<DayWorkController> logger,
        IWorkInfoService workInfoService
    )
    {
        _logger = logger;
        _workInfoService = workInfoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var workInfo = await _workInfoService.GetAll();
        return Ok(workInfo);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _workInfoService.GetById(id);
        return Ok(user);
    }
}
