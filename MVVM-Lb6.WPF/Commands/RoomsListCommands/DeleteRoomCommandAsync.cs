using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb6.HttpsClient;
using MVVM_Lb6.UIModels;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.Views.DialogWindows;

namespace MVVM_Lb6.Commands.RoomsListCommands;

internal class DeleteRoomCommandAsync : AsyncCommandBase
{
    private readonly RoomsListingViewModel _roomsListingViewModel;

    public DeleteRoomCommandAsync(RoomsListingViewModel roomsListingViewModel)
    {
        _roomsListingViewModel = roomsListingViewModel;
    }
    public override bool CanExecute(object parameter) => true;

    public override async Task ExecuteAsync(object parameter)
    {
        ConfirmOperationWindow createConfirmWindow = new ConfirmOperationWindow("delete selected room");

        if ((bool)createConfirmWindow.ShowDialog()!)
        {
            if (_roomsListingViewModel.SelectedUiRoom?.RoomId is null)
                throw new DataException("Oops. RoomId must be not null here");
            
            await WebRequestsController.DeleteRoomAsync(_roomsListingViewModel.SelectedUiRoom.RoomId);
            _roomsListingViewModel.LoadRooms();

            // MessageBox.Show($"The selected room has been successfully deleted",
            //     "Success action",
            //     MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}