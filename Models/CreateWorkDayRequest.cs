namespace TimeStatisticsSystem.Models.DayWork;

using System.ComponentModel.DataAnnotations;
using TimeStatisticsSystem.Entities;

public class CreateWorkDayRequest
{
    [Required]
    public required string 日期 { get; set; } 

    [Required]
    public required string 開始時間 { get; set; }

    [Required]
    [EnumDataType(typeof(MainCategory))]
    public required string 主要分類 { get; set; }

    [Required]
    [EnumDataType(typeof(SubCategory))]

    public required string 次要分類 { get; set; }

    [MaxLength(200)]
    public string? 備註 { get; set; }

    [Required]
    public int 花費時間 { get; set; }
}