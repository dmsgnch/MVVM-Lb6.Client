using System;
using System.Data;
using MVVM_lb6.Domain.Models;
using MVVM_Lb6.UIModels;
using MVVM_Lb6.ViewModels.Base;

namespace MVVM_Lb6.ViewModels;

public class HotelViewModel : ViewModel
{
    public RoomsListingViewModel RoomsListingViewModel { get; }
    public RoomInfoViewModel RoomInfoViewModel { get; }
    
    public Room GetRoomFromUiRoom(UiRoom? uiRoom)
    {
        if (uiRoom is null) throw new ArgumentException();
            
        return new Room()
        {
            RoomId = uiRoom?.RoomId ?? throw new DataException(),
            RealNumber = uiRoom?.RealNumber ?? throw new DataException(),
            BedsNumber = uiRoom?.BedsNumber ?? throw new DataException(),
            PricePerDay = uiRoom?.PricePerDay ?? throw new DataException(),
            IsAvailable = uiRoom?.IsAvailable ?? throw new DataException(),
        };
    }

    public HotelViewModel()
    {
        RoomsListingViewModel = new RoomsListingViewModel(this);
        RoomInfoViewModel = new RoomInfoViewModel(this);
    }
}