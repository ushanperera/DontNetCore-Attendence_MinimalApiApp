using DataAccess.DbAccess;
using DataAccess.Models;
using Mysqlx;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Data;

public class ShiftDataRepo : IShiftDataRepo
{
    private readonly ISqlDataAccess _db;

    public ShiftDataRepo(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ShiftData>> GetShiftData() =>
     _db.LoadDataQueryAsync<ShiftData, dynamic>("" +
         "SELECT " +

         "ShiftId," +
         "ShiftDate," +
         "WorkStartTime," +
         "WorkEndTime," +
         "MealBreakStartTime," +
         "MealBreakEndTime," +
         "IsPublicHoliday," +
         "IsWeekendShift," +
         "ShiftRemarks," +

         "RateId," +
         "Rate," +

         "TotalWorkedDuration," +
         "TotalMealBreakDuration," +
         "MealBreakGapDuration," +
         "MealBreakPenaltyDuration," +
         "NetWorkDuration," +
         "ExtraHoursWorkedDuration," +
         "WeekDayAntiSocialDuration," +

         "HourlyPay," +
         "ExtraHourPay," +
         "MealBreakPenaltyPay," +
         "PublicHolidayPenaltyPay," +
         "WeekEndPenaltyPay," +
         "WeekDayAntiSocialPay," +
         "TotalDayPay" +


         " FROM shiftData", new { });

    public Task<ShiftMonthlySummary> GetShiftSummaryData(DateTime? fromDate, DateTime? toDate)
    {

        var _fromDate = fromDate ?? DateTime.UtcNow;
        var _toDateo = toDate ?? DateTime.UtcNow;


        var sql = @"
         SELECT " +

         "ShiftId," +
         "ShiftDate," +
         "WorkStartTime," +
         "WorkEndTime," +
         "MealBreakStartTime," +
         "MealBreakEndTime," +
         "IsPublicHoliday," +
         "IsWeekendShift," +
         "ShiftRemarks," +

         "RateId," +
         "Rate," +

         "TotalWorkedDuration," +
         "TotalMealBreakDuration," +
         "MealBreakGapDuration," +
         "MealBreakPenaltyDuration," +
         "NetWorkDuration," +
         "ExtraHoursWorkedDuration," +
         "WeekDayAntiSocialDuration," +

         "HourlyPay," +
         "ExtraHourPay," +
         "MealBreakPenaltyPay," +
         "PublicHolidayPenaltyPay," +
         "WeekEndPenaltyPay," +
         "WeekDayAntiSocialPay," +
         "TotalDayPay" +


         " FROM shiftData" +
         " WHERE ShiftDate >= '" + _fromDate.ToString("yyyy-MM-dd") + "'" +
         " AND ShiftDate <= '" + _toDateo.ToString("yyyy-MM-dd") + "'" + ";";

        var debugQuery = _db.DebugFinalSQLQuerry(sql, new { });

        List<ShiftData> shiftDataList = _db.LoadDataQueryAsync<ShiftData, dynamic>(sql, new { }).Result.ToList();

        float numberOfHours = (float)shiftDataList.Sum(s => s.TotalWorkedDuration.TotalMinutes) / 60;
        float extraHoursWorkedDuration = (float)shiftDataList.Sum(s => s.ExtraHoursWorkedDuration.TotalMinutes) / 60;
        float totalPay = shiftDataList.Sum(s => s.TotalDayPay);

        ShiftMonthlySummary shiftMonthlySummary = new ShiftMonthlySummary
        {
            NumberOfHoursWorked = numberOfHours,
            ExtraHoursWorkedDuration = extraHoursWorkedDuration,
            TotalPay = totalPay
        };

        return Task.FromResult(shiftMonthlySummary);

    }


    public async Task<int> InsertShift(ShiftData shift)
    {
        // Check if a record already exists
        var existingRecords = await _db.LoadDataQueryAsync<ShiftData, dynamic>(
            "SELECT ShiftId FROM shiftData WHERE date(ShiftDate) = date(@ShiftDate)",
            new { shift.ShiftId, shift.ShiftDate }
        );

        string sql;
        if (!existingRecords.Any())
        {



            // Insert new shift
            sql = @"
            INSERT INTO shiftData (
                ShiftId, ShiftDate,
                WorkStartTime, WorkEndTime,
                MealBreakStartTime, MealBreakEndTime,
                IsPublicHoliday, IsWeekendShift, ShiftRemarks,
                RateId, Rate,
                TotalWorkedDuration,TotalMealBreakDuration, MealBreakGapDuration,
                MealBreakPenaltyDuration,NetWorkDuration,
                ExtraHoursWorkedDuration, WeekDayAntiSocialDuration,
                HourlyPay,ExtraHourPay,MealBreakPenaltyPay, PublicHolidayPenaltyPay, WeekEndPenaltyPay, WeekDayAntiSocialPay, TotalDayPay

            ) VALUES (
                @ShiftId, @ShiftDate,
                @WorkStartTime, @WorkEndTime,
                @MealBreakStartTime, @MealBreakEndTime,
                @IsPublicHoliday, @IsWeekendShift, @ShiftRemarks,
                @RateId, @Rate,
                @TotalWorkedDuration,@TotalMealBreakDuration, @MealBreakGapDuration,
                @MealBreakPenaltyDuration,@NetWorkDuration,
                @ExtraHoursWorkedDuration, @WeekDayAntiSocialDuration,
                @HourlyPay,@ExtraHourPay,@MealBreakPenaltyPay,@PublicHolidayPenaltyPay,@WeekEndPenaltyPay,@WeekDayAntiSocialPay,@TotalDayPay

            );";
        }
        else
        {
            // Update existing shift
            sql = @"
            UPDATE shiftData
            SET ShiftId = @ShiftId,
                WorkStartTime = @WorkStartTime,
                WorkEndTime = @WorkEndTime,
                MealBreakStartTime = @MealBreakStartTime,
                MealBreakEndTime = @MealBreakEndTime,
                IsPublicHoliday = @IsPublicHoliday,
                IsWeekendShift = @IsWeekendShift,
                ShiftRemarks = @ShiftRemarks,
                RateId = @RateId,
                Rate = @Rate,
                TotalWorkedDuration = @TotalWorkedDuration,
                TotalMealBreakDuration = @TotalMealBreakDuration,
                MealBreakGapDuration = @MealBreakGapDuration,
                MealBreakPenaltyDuration = @MealBreakPenaltyDuration,
                NetWorkDuration = @NetWorkDuration,
                ExtraHoursWorkedDuration = @ExtraHoursWorkedDuration,
                WeekDayAntiSocialDuration = @WeekDayAntiSocialDuration,
                HourlyPay = @HourlyPay,
                ExtraHourPay = @ExtraHourPay,
                MealBreakPenaltyPay = @MealBreakPenaltyPay,
                PublicHolidayPenaltyPay = @PublicHolidayPenaltyPay,
                WeekEndPenaltyPay = @WeekEndPenaltyPay,
                WeekDayAntiSocialPay = @WeekDayAntiSocialPay,
                TotalDayPay = @TotalDayPay


            WHERE ShiftDate = @ShiftDate;";
        }

        var debugQuery = _db.DebugFinalSQLQuerry(sql, shift);


        return await _db.SaveDataExecuteAsync(sql, shift);

        //return await _db.SaveDataExecuteAsync(sql, new
        //{
        //    shift.ShiftId,
        //    shift.ShiftDate,
        //    shift.WorkStartTime,
        //    shift.WorkEndTime,
        //    shift.MealBreakStartTime,
        //    shift.MealBreakEndTime,
        //    shift.IsPublicHoliday,
        //    shift.ShiftRemarks

        //});
    }


    //public Task<IEnumerable<ShiftData>> GetShifts() =>
    //    _db.LoadData<ShiftData, dynamic>("GetAllShiftData", new { });


    //public async Task<int> InsertShift(ShiftData shift)
    //{
    //    // Assuming ManageShiftData does an insert/update
    //    await _db.SaveData(
    //        "ManageShiftData",
    //        new
    //        {
    //            p_ShiftId = shift.ShiftId,
    //            p_ShiftDate = shift.ShiftDate,

    //            p_WorkStartTime = shift.WorkStartTime,
    //            p_WorkEndTime = shift.WorkEndTime,
    //            p_MealBreakStartTime = shift.MealBreakStartTime,
    //            p_MealBreakEndTime = shift.MealBreakEndTime,

    //            p_IsPublicHoliday = shift.IsPublicHoliday,
    //            p_ShiftRemarks = shift.ShiftRemarks,

    //            //p_RateId = shift.RateId,
    //            //p_Rate = shift.Rate,
    //            //p_IsWeekendShift = shift.IsWeekendShift

    //            //p_TotalWorkedDuration = shift.TotalWorkedDuration,
    //            //p_TotalMealBreakDuration = shift.TotalMealBreakDuration,
    //            //p_MealBreakGapDuration = shift.MealBreakGapDuration,
    //            //p_MealBreakPenaltyDuration = shift.MealBreakPenaltyDuration,
    //            //p_NetWorkDuration = shift.NetWorkDuration,
    //            //p_ExtraHoursWorkedDuration = shift.ExtraHoursWorkedDuration,


    //        });

    //    // Return the number of affected rows or the new ID
    //    return 1; // Adjust based on your needs
    //}

}
