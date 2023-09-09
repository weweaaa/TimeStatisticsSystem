namespace TimeStatisticsSystem.Repositories;

using Dapper;
using TimeStatisticsSystem.Entities;
using TimeStatisticsSystem.Helpers;

public interface IDayWorkRepository
{
    Task<IEnumerable<DayWork>> GetAll();
    Task<DayWork> GetById(int id);
    Task<DayWork> GetBy主要分類(MainCategory 主要分類);
    Task Create(DayWork dayWork);
    Task Update(DayWork dayWork);
    Task Delete(int id);
}

public class DayWorkRepository : IDayWorkRepository
{
    private DataContext _context;

    public DayWorkRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DayWork>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sqlStr = """
            SELECT * FROM DayWork
        """;
        return await connection.QueryAsync<DayWork>(sqlStr);
    }

    public async Task<DayWork> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sqlStr = """
            SELECT * FROM DayWork 
            WHERE ID = @ID
        """;
        return await connection.QuerySingleOrDefaultAsync<DayWork>(sqlStr, new { id });
    }

    public async Task<DayWork> GetBy主要分類(MainCategory 主要分類)
    {
        using var connection = _context.CreateConnection();
        var sqlStr = """
            SELECT * FROM DayWork 
            WHERE 主要分類 = @主要分類
        """;
        return await connection.QuerySingleOrDefaultAsync<DayWork>(sqlStr, new { 主要分類 });
    }

    public async Task Create(DayWork user)
    {
        using var connection = _context.CreateConnection();
        var sqlStr = """
            INSERT INTO DayWork (日期 ,開始時間, 主要分類, 次要分類, 備註, 花費時間)
            VALUES (@日期 ,@開始時間, @主要分類, @次要分類, @備註, @花費時間)
        """;
        await connection.ExecuteAsync(sqlStr, user);
    }

    public async Task Update(DayWork user)
    {
        using var connection = _context.CreateConnection();
        var sqlStr = """
            UPDATE DayWork 
            SET 日期 = @日期, 
                開始時間 = @開始時間,
                主要分類 = @主要分類,
                次要分類 = @次要分類,
                備註 = @備註,
                花費時間 = @花費時間
            WHERE ID = @ID
        """;
        await connection.ExecuteAsync(sqlStr, user);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sqlStr = """
            DELETE FROM DayWork 
            WHERE ID = @ID
        """;
        await connection.ExecuteAsync(sqlStr, new { id });
    }
}