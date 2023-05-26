using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MVVM_Lb6.Commands.RoomsListCommands;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.ViewModels.Base;
using MVVM_lb6.Domain.Models;
using MVVM_Lb6.HttpsClient;
using MVVM_Lb6.UIModels;

namespace MVVM_Lb6.ViewModels
{
    public class RoomsListingViewModel : ViewModel
    {
        #region ViewGroupList

        private List<UiRoom> _uiRoomsListView =
            new List<UiRoom>();

        public List<UiRoom> UiRoomsListView
        {
            get => _uiRoomsListView;
            set => Set(ref _uiRoomsListView, value);
        }

        #endregion

        #region Params

        private HotelViewModel HotelViewModel { get; }

        #region UiRoom

        private UiRoom _uiRoom = new UiRoom();

        public UiRoom UiRoom
        {
            get => _uiRoom;
            set { Set(ref _uiRoom, value); }
        }

        #endregion


        #region SelectedRoom

        private UiRoom? _selectedUiRoom = null;

        public UiRoom? SelectedUiRoom
        {
            get => _selectedUiRoom;
            set
            {
                Set(ref _selectedUiRoom, value);

                HotelViewModel.RoomInfoViewModel.UiRoom = _selectedUiRoom;

                OnPropertyChanged(nameof(RoomIsSelected));
            }
        }

        #region RoomIsSelected

        public bool RoomIsSelected
        {
            get => SelectedUiRoom is not null;
        }

        #endregion

        #endregion

        #endregion


        #region Commands

        public ICommand CreateRoomCommandAsync
        {
            get => new CreateRoomCommandAsync(this);
        }

        public ICommand DeleteRoomCommandAsync
        {
            get => new DeleteRoomCommandAsync(this);
        }

        public ICommand UpdateRoomCommandAsync
        {
            get => new UpdateRoomCommandAsync(this);
        }

        #endregion

        public RoomsListingViewModel(HotelViewModel hotelViewModel)
        {
            HotelViewModel = hotelViewModel;

            LoadRooms();
        }

        public async void LoadRooms()
        {
            IEnumerable<Room> rooms = await WebRequestsController.LoadRoomsAsync();

            UiRoomsListView = rooms.Select(r => new UiRoom()
            {
                RoomId = r.RoomId,
                RealNumber = r.RealNumber,
                BedsNumber = r.BedsNumber,
                PricePerDay = r.PricePerDay,
                IsAvailable = r.IsAvailable
            }).ToList();
        }
    }
}