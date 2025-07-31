using DataAccess.Models;

namespace DataAccess.Repositories.Data;
public interface IShiftDataRepo
{
    //Task<IEnumerable<ShiftData>> GetShifts();


    public Task<IEnumerable<ShiftData>> GetShiftData();
    public Task<ShiftMonthlySummary> GetShiftSummaryData(DateTime ?fromDate, DateTime ?toDate);

    Task<int> InsertShift(ShiftData shift);



}