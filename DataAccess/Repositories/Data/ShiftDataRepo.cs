using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Repositories.Data;

public class ShiftDataRepo : IShiftDataRepo
{
    private readonly ISqlDataAccess _db;

    public ShiftDataRepo(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ShiftData>> GetShifts() =>
        _db.LoadData<ShiftData, dynamic>("GetAllShiftData", new { });


    public async Task<int> InsertShift(ShiftData shift)
    {
        // Assuming ManageShiftData does an insert/update
        await _db.SaveData(
            "ManageShiftData",
            new
            {
                p_ShiftId = shift.ShiftId,
                p_ShiftDate = shift.ShiftDate,

                p_WorkStartTime = shift.WorkStartTime,
                p_WorkEndTime = shift.WorkEndTime,
                p_MealBreakStartTime = shift.MealBreakStartTime,
                p_MealBreakEndTime = shift.MealBreakEndTime,

                p_IsPublicHoliday = shift.IsPublicHoliday,
                p_ShiftRemarks = shift.ShiftRemarks,

                //p_RateId = shift.RateId,
                //p_Rate = shift.Rate,
                //p_IsWeekendShift = shift.IsWeekendShift

                //p_TotalWorkedDuration = shift.TotalWorkedDuration,
                //p_TotalMealBreakDuration = shift.TotalMealBreakDuration,
                //p_MealBreakGapDuration = shift.MealBreakGapDuration,
                //p_MealBreakPenaltyDuration = shift.MealBreakPenaltyDuration,
                //p_NetWorkDuration = shift.NetWorkDuration,
                //p_ExtraHoursWorkedDuration = shift.ExtraHoursWorkedDuration,


            });

        // Return the number of affected rows or the new ID
        return 1; // Adjust based on your needs
    }



}
