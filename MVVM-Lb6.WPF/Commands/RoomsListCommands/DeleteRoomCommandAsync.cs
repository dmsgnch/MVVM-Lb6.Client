using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb6.UIModels;

namespace MVVM_Lb6.Commands.RoomsListCommands;

internal class DeleteRoomCommandAsync : AsyncCommandBase
{
    private readonly Guid _roomId;

    public DeleteRoomCommandAsync(Guid roomId)
    {
        _roomId = roomId;
    }
    public override bool CanExecute(object parameter) => true;

    public override async Task ExecuteAsync(object parameter)
    {
        
    }
}