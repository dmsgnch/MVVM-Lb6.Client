﻿using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Input;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.ViewModels.Base;
using MVVM_Lb6.Commands.RoomInfoCommands;
using MVVM_Lb6.UIModels;

namespace MVVM_Lb6.ViewModels;

public class RoomInfoViewModel : ViewModel
{
    #region Params

    #region Room

    private UiRoom? _uiRroom;

    public UiRoom? UiRoom
    {
        get => _uiRroom;
        set
        {
            Set(ref _uiRroom, value);

            if (value is not null)
            {
                RoomIsSelected = true;
            }
            else if (value is null)
            {
                RoomIsSelected = false;
            }
        } 
    }

    #endregion

    public HotelViewModel HotelViewModel { get; }


    #region Commands

    public ICommand BookTheRoomCommand
    {
        get => new BookRoomCommandAsync(HotelViewModel.GetRoomFromUiRoom(UiRoom));
    }

    public ICommand PopulateTheRoomCommand
    {
        get => new PopulateRoomCommandAsync(HotelViewModel.GetRoomFromUiRoom(UiRoom));
    }
    
    #endregion
    
    #region RoomIsSelected
    
    private bool _roomIsSelected = false;
    public bool RoomIsSelected
    {
        get => _roomIsSelected; 
        set => Set(ref _roomIsSelected, value); 
    }
    
    #endregion

    #endregion Params

    public RoomInfoViewModel(HotelViewModel hotelViewModel)
    {
        HotelViewModel = hotelViewModel;
    }
}