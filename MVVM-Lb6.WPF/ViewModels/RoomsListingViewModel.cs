using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        
        #region SelectedRoom

        private UiRoom? _selectedUiRoom = null;

        public UiRoom? SelectedUiRoom
        {
            get => _selectedUiRoom;
            set
            {
                Set(ref _selectedUiRoom, value);

                HotelViewModel.RoomInfoViewModel.UiRoom = _selectedUiRoom;
            }
        }

       
        
        #endregion

        #endregion


        #region Commands

        public ICommand AddRoomCommandAsync
        {
            get => new AddRoomCommandAsync(HotelViewModel.GetRoomFromUiRoom(SelectedUiRoom));
        }
        public ICommand DeleteRoomCommandAsync
        {
            get => new DeleteRoomCommandAsync(SelectedUiRoom?.RoomId ?? 
                                              throw new DataException());
        }
        public ICommand EditRoomCommandAsync
        {
            get => new EditRoomCommandAsync(HotelViewModel.GetRoomFromUiRoom(SelectedUiRoom));
        }
        
        #endregion

        public RoomsListingViewModel(HotelViewModel hotelViewModel)
        {
            HotelViewModel = hotelViewModel;

            LoadGroups();
        }

        public async void LoadGroups()
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