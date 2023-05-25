using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using MVVM_lb6.Domain.Models;
using Newtonsoft.Json;
using SharedLibrary.Responses;

namespace MVVM_Lb6.HttpsClient;

public static class WebRequestsController
{
    static WebRequestsController()
    {
        
    }

    public static async Task<IEnumerable<Room>> LoadRoomsAsync()
    {
        GetRoomsResponse response = await RequestCreator.Request<GetRoomsResponse>(HttpMethod.Get,  "room/getAll");

        return response.Rooms;
    }

    public static async Task AddRoomAsync(Room room)
    {
        AddRoomResponse response = await RequestCreator.Request<AddRoomResponse>(HttpMethod.Post , "room/add", room);
    }
    
    public static async Task DeleteRoomAsync(Guid id)
    {
        DeleteRoomResponse response = await RequestCreator.Request<DeleteRoomResponse>(HttpMethod.Delete , "room/delete", id);
    }
    
    public static async Task EditRoomAsync(Room room)
    {
        EditRoomResponse response = await RequestCreator.Request<EditRoomResponse>(HttpMethod.Put , "room/update", room);
    }
}