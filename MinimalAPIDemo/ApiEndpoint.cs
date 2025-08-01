﻿namespace Attendence_MinimalAPI;

public static class ApiEndpoint
{
    public static void ConfigureEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "API is running!");


        app.MapGet("/shiftData", GetShiftData);
        app.MapGet("/shiftDataSummary", GetShiftSummary);

        app.MapPost("/shiftData", InsertShift);

        //app.MapPut("/users/{id:int}", UpdateUser);
        //app.MapDelete("/users/{id:int}", DeleteUser);


    }

    private static async Task<IResult> GetShiftData(IShiftDataRepo data)
    {
        try
        {
            var shifts = await data.GetShiftData();
            return Results.Ok(shifts);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetShiftSummary(IShiftDataRepo data, DateTime ?fromDate , DateTime ?toDate)
    {
        try
        {
       
            var shifts = await data.GetShiftSummaryData(fromDate, toDate);
            return Results.Ok(shifts);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertShift(IShiftDataRepo repo, ShiftData shift)
    {
        try
        {
            var result = await repo.InsertShift(shift);

            return Results.Created($"/shift/{shift.Id}", shift);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }



    //IShiftData data is comming from the global using ile, so no need to inject seperately
    //private static async Task<IResult> GetShiftDataSP(IShiftDataRepo data)
    //{
    //    try
    //    {
    //        var shifts = await data.GetShiftsData();
    //        return Results.Ok(shifts);
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}








}