using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_lb6.Domain.Models;
using MVVM_Lb6.UIModels;

namespace MVVM_Lb6.Commands.RoomsListCommands;

internal class EditRoomCommandAsync : AsyncCommandBase
{
    private readonly Room _room;

    public EditRoomCommandAsync(Room room)
    {
        _room = room;
    }
    public override bool CanExecute(object parameter) => true;

    public override async Task ExecuteAsync(object parameter)
    {
        
    }
}