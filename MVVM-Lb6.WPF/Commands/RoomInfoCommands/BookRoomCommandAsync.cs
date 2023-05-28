using System;
using System.Data;
using System.Threading.Tasks;
using MVVM_Lb6.Commands.Base;
using MVVM_lb6.Domain.Requests;
using MVVM_Lb6.HttpsClient;
using MVVM_Lb6.UIModels;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.Views.DialogWindows;

namespace MVVM_Lb6.Commands.RoomInfoCommands;

internal class BookRoomCommandAsync : AsyncCommandBase
{
    private readonly RoomInfoViewModel _roomInfoViewModel;

    public BookRoomCommandAsync(RoomInfoViewModel roomInfoViewModel)
    {
        _roomInfoViewModel = roomInfoViewModel;
    }

    public override bool CanExecute(object parameter) => true;

    public override async Task ExecuteAsync(object parameter)
    {
        _roomInfoViewModel.SelectedFirstDate = DateTime.Today;
        _roomInfoViewModel.SelectedSecondDate = DateTime.Today;

        EnterDates createRoomWindow = new EnterDates(_roomInfoViewModel, "Booking the room");

        if ((bool)createRoomWindow.ShowDialog()!)
        {
            UIValidator uiValidator = new UIValidator();
            if (!await uiValidator.IsValidateBookingDateAsync(DateTime.Today.AddDays(1), _roomInfoViewModel.SelectedFirstDate,
                    _roomInfoViewModel.SelectedSecondDate)) return;

            BookingStayRoomRequest createRoomRequest = new BookingStayRoomRequest()
            {
                RoomId = _roomInfoViewModel.HotelViewModel.RoomsListingViewModel.SelectedUiRoom?.RoomId ??
                         throw new DataException(),
                FirstDate = _roomInfoViewModel.SelectedFirstDate,
                SecondDate = _roomInfoViewModel.SelectedSecondDate
            };

            await WebRequestsController.BookRoomAsync(createRoomRequest);
        }
    }
}