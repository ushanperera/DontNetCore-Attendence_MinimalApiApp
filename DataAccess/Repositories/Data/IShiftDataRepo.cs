using DataAccess.Models;

namespace DataAccess.Repositories.Data;
public interface IShiftDataRepo
{
    Task<IEnumerable<ShiftData>> GetShifts();

    Task<int> InsertShift(ShiftData shift);


}