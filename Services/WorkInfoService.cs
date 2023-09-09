namespace TimeStatisticsSystem.Services;

using TimeStatisticsSystem.Entities;
using TimeStatisticsSystem.Helpers;
using TimeStatisticsSystem.Models.DayWork;
using TimeStatisticsSystem.Repositories;

public interface IWorkInfoService
{
    Task<IEnumerable<DayWork>> GetAll();
    Task<DayWork> GetById(int id);
    Task Create(CreateWorkDayRequest model);
    Task Update(int id, UpdateWorkDayRequest model);
    Task Delete(int id);
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

    public async Task Create(CreateWorkDayRequest model)
    {
        if (!Enum.TryParse(model.主要分類, out MainCategory 主要分類))
        {
            throw new AppException("主要分類 is not valid");
        }

        if (!Enum.TryParse(model.次要分類, out SubCategory 次要分類))
        {
            throw new AppException("次要分類 is not valid");
        }

        var dayWork = new DayWork
        {
            日期 = model.日期,
            開始時間 = model.開始時間,
            主要分類 = 主要分類,
            次要分類 = 次要分類,
            備註 = model.備註,
            花費時間 = model.花費時間,
            起始結束 = model.起始結束
        };

        await _dayWorkRepository.Create(dayWork);
    }

    public async Task Update(int id, UpdateWorkDayRequest model)
    {
        var dayWork = await _dayWorkRepository.GetById(id);

        if (dayWork == null)
            throw new KeyNotFoundException("DayWork data not found");

        if (model.日期 != null)
        {
            dayWork.日期 = model.日期;
        }

        if (model.開始時間 != null)
        {
            dayWork.開始時間 = model.開始時間;
        }

        if (model.主要分類 != null)
        {
            if (!Enum.TryParse(model.主要分類, out MainCategory 主要分類))
            {
                throw new AppException("主要分類 is not valid");
            }

            dayWork.主要分類 = 主要分類;
        }

        if (model.次要分類 != null)
        {
            if (!Enum.TryParse(model.次要分類, out SubCategory 次要分類))
            {
                throw new AppException("次要分類 is not valid");
            }

            dayWork.次要分類 = 次要分類;
        }

        if (model.備註 != null)
        {
            dayWork.備註 = model.備註;
        }

        if (model.花費時間 != null)
        {
            dayWork.花費時間 = (int)model.花費時間;
        }

        // 起始結束 可為 NULL
        dayWork.起始結束 = model.起始結束;

        await _dayWorkRepository.Update(dayWork);
    }

    public async Task Delete(int id)
    {
        var dayWork = await _dayWorkRepository.GetById(id);

        if (dayWork == null)
            throw new KeyNotFoundException("DayWork data not found");

        await _dayWorkRepository.Delete(id);
    }
}