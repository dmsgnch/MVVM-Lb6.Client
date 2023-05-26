using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_lb6.Domain.Models;
using MVVM_lb6.Domain.Requests;
using MVVM_Lb6.HttpsClient;
using MVVM_Lb6.UIModels;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.Views.DialogWindows;

namespace MVVM_Lb6.Commands.RoomsListCommands;

internal class UpdateRoomCommandAsync : AsyncCommandBase
{
    private readonly RoomsListingViewModel _roomsListingViewModel;

    public UpdateRoomCommandAsync(RoomsListingViewModel roomsListingViewModel)
    {
        _roomsListingViewModel = roomsListingViewModel;
    }
    public override bool CanExecute(object parameter) => true;

    public override async Task ExecuteAsync(object parameter)
    {
        _roomsListingViewModel.UiRoom = new UiRoom();
        _roomsListingViewModel.UiRoom = (UiRoom)_roomsListingViewModel.SelectedUiRoom.Clone();
        
        CreateRoomWindow createConfirmWindow = new CreateRoomWindow(_roomsListingViewModel, "Updating the room");

        if ((bool)createConfirmWindow.ShowDialog()!)
        {
            UIValidator uiValidator = new UIValidator();
            if (!await uiValidator.IsValidateRoomUIParamsAsync(_roomsListingViewModel.UiRoom)) return;
            
            if (_roomsListingViewModel.SelectedUiRoom?.RoomId is null)
                throw new DataException("Oops. RoomId must be not null here");

            if (_roomsListingViewModel.UiRoom.Equals(_roomsListingViewModel.SelectedUiRoom))
            {
                MessageBox.Show($"You didn`t make any changes",
                    "Operation warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UpdateRoomRequest updateRoomRequest = new UpdateRoomRequest()
            {
                RoomId = _roomsListingViewModel.SelectedUiRoom.RoomId,
                BedsNumber = _roomsListingViewModel.UiRoom.BedsNumber,
                PricePerDay = _roomsListingViewModel.UiRoom.PricePerDay,
                RealNumber = _roomsListingViewModel.UiRoom.RealNumber,
                IsAvailable = _roomsListingViewModel.UiRoom.IsAvailable,
            };
            
            await WebRequestsController.UpdateRoomAsync(updateRoomRequest);
            _roomsListingViewModel.LoadRooms();
        }
    }
}