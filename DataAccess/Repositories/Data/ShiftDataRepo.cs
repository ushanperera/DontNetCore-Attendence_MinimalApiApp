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


}
