﻿namespace Attendence_MinimalAPI;

public static class ApiEndpoint
{
    public static void ConfigureEndpoints(this WebApplication app)
    {

        app.MapGet("/shiftData", GetShiftData);

        app.MapPost("/shiftData", InsertShift);


        // Add route mapping for GetUsers
        //app.MapGet("/users", GetUsers);
        //app.MapGet("/users/{id:int}", GetUser);
        //app.MapPost("/users", InsertUser);
        //app.MapPut("/users/{id:int}", UpdateUser);
        //app.MapDelete("/users/{id:int}", DeleteUser);


    }




    //IShiftData data is comming from the global using ile, so no need to inject seperately
    private static async Task<IResult> GetShiftData(IShiftDataRepo data)
    {
        try
        {
            var shifts = await data.GetShifts();
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




    //private static async Task<IResult> GetUsers(IUserData data)
    //{
    //    //try
    //    //{
    //        var users = await data.GetUsers();
    //        return Results.Ok(users);
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    return Results.Problem(ex.Message);
    //    //}
    //}

    //private static async Task<IResult> GetUser(int id, IUserData data)
    //{
    //    try
    //    {
    //        var user = await data.GetUser(id);
    //        return user is not null ? Results.Ok(user) : Results.NotFound();
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}


    //private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    //{
    //    try
    //    {
    //        await data.InsertUser(user);
    //        return Results.Created($"/users/{user.Id}", user);
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}

    //private static async Task<IResult> UpdateUser(int id, UserModel user, IUserData data)
    //{
    //    try
    //    {
    //        user.Id = id; // Ensure the ID is set for the update
    //        await data.UpdateUser(user);
    //        return Results.Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}

    //private static async Task<IResult> DeleteUser(int id, IUserData data)
    //{
    //    try
    //    {
    //        await data.DeleteUser(id);
    //        return Results.NoContent();
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}



}