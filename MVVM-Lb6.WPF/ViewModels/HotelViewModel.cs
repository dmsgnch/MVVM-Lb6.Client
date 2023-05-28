using System.Windows.Input;
using MVVM_Lb6.Commands.HotelCommands;
using MVVM_Lb6.Commands.MainCommands;
using MVVM_Lb6.ViewModels.Base;

namespace MVVM_Lb6.ViewModels;

public class HotelViewModel : ViewModel
{
    #region ViewModels

    public RoomsListingViewModel RoomsListingViewModel { get; }
    public RoomInfoViewModel RoomInfoViewModel { get; }

    #endregion

    #region Commands

    public ICommand GetAllAvailableRoomsCommandAsync { get; }
    public ICommand CloseApplicationCommand { get; }

    #endregion

    #region Params

    private bool _stopAccommodationIsSelected = false;

    public bool StopAccommodationIsSelected
    {
        get => _stopAccommodationIsSelected;
        set => Set(ref _stopAccommodationIsSelected, value);
    }

    private bool _holidaySeasonIsSelected = true;

    public bool HolidaySeasonIsSelected
    {
        get => _holidaySeasonIsSelected;
        set => Set(ref _holidaySeasonIsSelected, value);
    }

    #endregion

    public HotelViewModel()
    {
        CloseApplicationCommand = new CloseApplicationCommand();

        RoomsListingViewModel = new RoomsListingViewModel(this);
        RoomInfoViewModel = new RoomInfoViewModel(this);

        GetAllAvailableRoomsCommandAsync = new GetAllAvailableRoomsCommandAsync();
    }
}