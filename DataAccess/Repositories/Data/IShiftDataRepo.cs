using DataAccess.Models;

namespace DataAccess.Repositories.Data;
public interface IShiftDataRepo
{
    //Task<IEnumerable<ShiftData>> GetShifts();


    public Task<IEnumerable<ShiftData>> GetShiftData();
    Task<int> InsertShift(ShiftData shift);



}