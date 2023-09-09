namespace TimeStatisticsSystem.Services;

using TimeStatisticsSystem.Entities;
using TimeStatisticsSystem.Helpers;
using TimeStatisticsSystem.Models.DayWork;
using TimeStatisticsSystem.Repositories;

public interface IWorkInfoService
{
    Task<IEnumerable<DayWork>> GetAll();
    Task<DayWork> GetById(int id);
}

public class WorkInfoService : IWorkInfoService
{
    private IDayWorkRepository _dayWorkRepository;

    public WorkInfoService(
        IDayWorkRepository dayWorkRepository)
    {
        _dayWorkRepository = dayWorkRepository;
    }

    public async Task<IEnumerable<DayWork>> GetAll()
    {
        return await _dayWorkRepository.GetAll();
    }

    public async Task<DayWork> GetById(int id)
    {
        var user = await _dayWorkRepository.GetById(id);

        if (user == null)
            throw new KeyNotFoundException("DayWork data not found");

        return user;
    }

    // TODO CRUD
}