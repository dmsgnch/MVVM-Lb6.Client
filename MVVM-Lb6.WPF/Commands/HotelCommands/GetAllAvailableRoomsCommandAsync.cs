using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb6.Commands.Base;
using MVVM_lb6.Domain.Models;
using MVVM_Lb6.HttpsClient;

namespace MVVM_Lb6.Commands.HotelCommands;

internal class GetAllAvailableRoomsCommandAsync : AsyncCommandBase
{
    public override bool CanExecute(object parameter) => true;

    public override async Task ExecuteAsync(object parameter)
    {
        var rooms = await WebRequestsController.GetAllAvailableRoomsAsync();

        StringBuilder sb = new StringBuilder();
        sb.Append("Available rooms numbers: \n");
        
        foreach (Room room in rooms)
        {
            sb.Append($"{room.RealNumber}\n");
        }
        
        MessageBox.Show(
                         $"{sb.ToString()}",
                         "List of available rooms",
                         MessageBoxButton.OK, MessageBoxImage.Information);
    }
}