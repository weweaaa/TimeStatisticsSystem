namespace TimeStatisticsSystem.Models.DayWork;

using System.ComponentModel.DataAnnotations;
using TimeStatisticsSystem.Entities;

public class UpdateWorkDayRequest
{
    public string? 日期 { get; set; } 
    public string? 開始時間 { get; set; }

    [EnumDataType(typeof(MainCategory))]
    public string? 主要分類 { get; set; }

    [EnumDataType(typeof(SubCategory))]
    public string? 次要分類 { get; set; }

    [MinLength(200)]
    public string? 備註 { get; set; }

    public int? 花費時間 { get; set; }

    public string? 起始結束 { get; set; }
}