
namespace DataAccess.Models;
public class ShiftData
{
    public int Id { get; set; }
    public int ShiftId { get; set; }
    public DateTime ShiftDate { get; set; }

    public TimeSpan WorkStartTime { get; set; }
    public TimeSpan WorkEndTime { get; set; }
    public TimeSpan? MealBreakStartTime { get; set; } 
    public TimeSpan? MealBreakEndTime { get; set; }

    public bool IsPublicHoliday { get; set; } = false;
    public bool IsWeekendShift { get; set; } = false;
    public string ShiftRemarks { get; set; }

    public int RateId { get; set; }
    public float Rate { get; set; }

    public TimeSpan TotalWorkedDuration { get; set; }
    public TimeSpan TotalMealBreakDuration { get; set; }
    public TimeSpan MealBreakGapDuration { get; set; }
    public TimeSpan MealBreakPenaltyDuration { get; set; }
    public TimeSpan NetWorkDuration { get; set; }
    public TimeSpan ExtraHoursWorkedDuration { get; set; }
    public TimeSpan WeekDayAntiSocialDuration { get; set; }
    public TimeSpan WeekDayLateNightDuration { get; set; }
    public TimeSpan WeekEndMoreThanEightDuration { get; set; }


    public float HourlyPay { get; set; }
    public float ExtraHourPay { get; set; }
    public float MealBreakPenaltyPay { get; set; }
    public float PublicHolidayPenaltyPay { get; set; }
    public float WeekEndPenaltyPay { get; set; }
    public float WeekDayAntiSocialPay { get; set; }
    public float WeekDayLateNightPay { get; set; }
    public float WeekEndMoreThanEightPay { get; set; }
    
        
    public float TotalDayPay { get; set; }
}
