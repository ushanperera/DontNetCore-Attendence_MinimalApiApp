
namespace DataAccess.Models;
public class ShiftData
{
    public int Id { get; set; }
    public int ShiftId { get; set; }
    public DateTime ShiftDate { get; set; }

    public string WorkStartTime { get; set; }
    public string WorkEndTime { get; set; }
    public string MealBreakStartTime { get; set; }
    public string MealBreakEndTime { get; set; }

    public bool IsPublicHoliday { get; set; } = false;
    public string ShiftRemarks { get; set; }

    //public int RateId { get; set; }
    //public float Rate { get; set; }

    //public bool IsWeekendShift { get; set; }

    //public string TotalWorkedDuration { get; set; }
    //public string TotalMealBreakDuration { get; set; }
    //public string MealBreakGapDuration { get; set; }
    //public string MealBreakPenaltyDuration { get; set; }
    //public string NetWorkDuration { get; set; }
    //public string ExtraHoursWorkedDuration { get; set; }

    //public int HourlyPay { get; set; }
    //public int ExtraHourPay { get; set; }
    //public int MealBreakPenaltyPay { get; set; }
    //public int PublicHolidayPenaltyPay { get; set; }
    //public int WeekEndPenaltyPay { get; set; }
    //public int TotalDayPay { get; set; }
}
