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
        var workInfo = await _workInfoService.GetById(id);
        return Ok(workInfo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkDayRequest model)
    {
        await _workInfoService.Create(model);
        return Ok(new { message = "workInfo created" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateWorkDayRequest model)
    {
        await _workInfoService.Update(id, model);
        return Ok(new { message = "workInfo updated" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _workInfoService.Delete(id);
        return Ok(new { message = "workInfo deleted" });
    }
}
