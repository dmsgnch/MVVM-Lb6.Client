using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb6.Commands.MainCommands;
using MVVM_lb6.Domain.Models;
using MVVM_lb6.Domain.Requests;
using MVVM_lb6.Domain.Responses;
using MVVM_lb6.Domain.Routes;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.Views;

namespace MVVM_Lb6.HttpsClient;

public static class WebRequestsController
{
    public static async Task RegisterRequestAsync(RegistrationRequest registrationRequest)
    {
        LambdaResponse response = 
            await RequestCreator.Request<LambdaResponse>(HttpMethod.Post, "Authentication/Register", registrationRequest);

        DisplayResuestResult(response.Info);
    }
    
    public static async Task LoginRequestAsync(LoginRequest loginRequest)
    {
        AuthenticationResponse response = 
            await RequestCreator.Request<AuthenticationResponse>(HttpMethod.Post, "Authentication/Login", loginRequest);

        DisplayResuestResult(response.Info);

        RequestCreator.Token = response?.Token ?? throw new DataException("Token must be not null");
    }

    public static async Task<IList<Room>> LoadRoomsAsync()
    {
        GetAllRoomsResponse response = await RequestCreator.Request<GetAllRoomsResponse>(HttpMethod.Get, "Room/GetAllRooms");
        return response.Rooms;
    }
    
    public static async Task<IList<Room>> GetAllAvailableRoomsAsync()
    {
        GetAllRoomsResponse response = await RequestCreator.Request<GetAllRoomsResponse>(HttpMethod.Get, "Room/GetAvailable");
        return response.Rooms;
    }

    public static async Task CreateRoomAsync(CreateRoomRequest request)
    {
        LambdaResponse response = await RequestCreator.Request<LambdaResponse>(HttpMethod.Post , "Room/Create", request);

        DisplayResuestResult(response.Info);
    }
    
    public static async Task DeleteRoomAsync(Guid id)
    {
        LambdaResponse response = await RequestCreator.Request<LambdaResponse>(HttpMethod.Delete , $"Room/Delete/{id}");
        
        DisplayResuestResult(response.Info);
    }
    
    public static async Task UpdateRoomAsync(UpdateRoomRequest request)
    {
        LambdaResponse response = await RequestCreator.Request<LambdaResponse>(HttpMethod.Put , "Room/Update", request);
        
        DisplayResuestResult(response.Info);
    }
    
    public static async Task BookRoomAsync(BookingStayRoomRequest request)
    {
        LambdaResponse response = await RequestCreator.Request<LambdaResponse>(HttpMethod.Put , "Room/book", request);
        
        DisplayResuestResult(response.Info);
    }
    
    public static async Task StayInRoomAsync(BookingStayRoomRequest request)
    {
        LambdaResponse response = await RequestCreator.Request<LambdaResponse>(HttpMethod.Put , "Room/stay", request);
        
        DisplayResuestResult(response.Info);
    }


    private static void DisplayResuestResult(string[]? result)
    {
        if (result is null) throw new DataException();
        
        for(int i = 0; i < result.Length; i++)
        {
            MessageBox.Show(result[0], "Operation result", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}