using System;
using System.Data;
using System.Windows.Input;
using MVVM_Lb6.Commands.MainCommands;
using MVVM_lb6.Domain.Models;
using MVVM_Lb6.UIModels;
using MVVM_Lb6.ViewModels.Base;

namespace MVVM_Lb6.ViewModels;

public class HotelViewModel : ViewModel
{
    
    #region ViewModels
    
    public RoomsListingViewModel RoomsListingViewModel { get; }
    public RoomInfoViewModel RoomInfoViewModel { get; }
    
    #endregion
    
    #region Commands

    public ICommand CloseApplicationCommand { get; }
    
    #endregion

    #region Params

    private bool _stopAccommodationIsSelected = false;
    
    public bool StopAccommodationIsSelected
    {
        get => _stopAccommodationIsSelected;
        set
        {
            Set(ref _stopAccommodationIsSelected, value);
            
            HolidaySeasonIsSelected = !value;
        }
    }
    
    private bool _holidaySeasonIsSelected = true;
    
    public bool HolidaySeasonIsSelected
    {
        get => _holidaySeasonIsSelected;
        set
        {
            Set(ref _holidaySeasonIsSelected, value);

            StopAccommodationIsSelected = !value;
        }
    }

    #endregion

    // public Room GetRoomFromUiRoom(UiRoom? uiRoom)
    // {
    //     if (uiRoom is null) throw new ArgumentException();
    //
    //     return new Room()
    //     {
    //         RoomId = uiRoom?.RoomId ?? throw new DataException(),
    //         RealNumber = uiRoom?.RealNumber ?? throw new DataException(),
    //         BedsNumber = uiRoom?.BedsNumber ?? throw new DataException(),
    //         PricePerDay = uiRoom?.PricePerDay ?? throw new DataException(),
    //         IsAvailable = uiRoom?.IsAvailable ?? throw new DataException(),
    //     };
    // }

    public HotelViewModel()
    {
        CloseApplicationCommand = new CloseApplicationCommand();
        
        RoomsListingViewModel = new RoomsListingViewModel(this);
        RoomInfoViewModel = new RoomInfoViewModel(this);
    }
}