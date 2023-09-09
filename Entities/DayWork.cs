namespace TimeStatisticsSystem.Entities;

/// <summary>
/// 時間紀錄資料 (每天)
/// </summary>
public class DayWork
{
    /// <summary> ID </summary>
    public int id { get; set; }

    /// <summary> 日期 </summary>
    public required string 日期 { get; set; } 
    
    /// <summary> 開始時間 </summary>
    public required string 開始時間 { get; set; }

    /// <summary> 主要分類 </summary>
    public MainCategory 主要分類 { get; set; }

    /// <summary> 次要分類 </summary>
    public SubCategory 次要分類 { get; set; }

    /// <summary> 備註 </summary>
    public string? 備註 { get; set; }

    /// <summary> 花費時間 (分鐘) </summary>
    public int 花費時間 { get; set; }
}
