using System.Threading.Tasks;
using MVVM_Lb6.Commands.Base;
using MVVM_lb6.Domain.Requests;
using MVVM_Lb6.HttpsClient;
using MVVM_Lb6.UIModels;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.Views.DialogWindows;

namespace MVVM_Lb6.Commands.RoomsListCommands;

internal class CreateRoomCommandAsync : AsyncCommandBase
{
    private readonly RoomsListingViewModel _roomsListingViewModel;

    public CreateRoomCommandAsync(RoomsListingViewModel roomsListingViewModel)
    {
        _roomsListingViewModel = roomsListingViewModel;
    }

    public override bool CanExecute(object parameter) => true;

    public override async Task ExecuteAsync(object parameter)
    {
        _roomsListingViewModel.UiRoom = new UiRoom();
        CreateRoomWindow createRoomWindow = new CreateRoomWindow(_roomsListingViewModel, "Creating a new room");

        if ((bool)createRoomWindow.ShowDialog()!)
        {
            UIValidator uiValidator = new UIValidator();
            if (!await uiValidator.IsValidateRoomUIParamsAsync(_roomsListingViewModel.UiRoom)) return;
            
            CreateRoomRequest createRoomRequest = new CreateRoomRequest()
            {
                BedsNumber = _roomsListingViewModel.UiRoom.BedsNumber,
                PricePerDay = _roomsListingViewModel.UiRoom.PricePerDay,
                RealNumber = _roomsListingViewModel.UiRoom.RealNumber,
                IsAvailable = _roomsListingViewModel.UiRoom.IsAvailable,
            };
            
            await WebRequestsController.CreateRoomAsync(createRoomRequest);
            _roomsListingViewModel.LoadRooms();

            // MessageBox.Show($"The room with number {_roomsListingViewModel.UiRoom.RealNumber} has been successfully created",
            //     "Success action",
            //     MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}