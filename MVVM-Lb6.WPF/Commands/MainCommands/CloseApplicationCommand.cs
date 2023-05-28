using System.Windows;
using MVVM_Lb6.Commands.Base;
using MVVM_Lb6.Views.DialogWindows;

namespace MVVM_Lb6.Commands.MainCommands;

internal class CloseApplicationCommand : CommandBase
{
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter)
    {
        ConfirmOperationWindow confirmOperationWindow = new ConfirmOperationWindow("quit the application");

        if ((bool)confirmOperationWindow.ShowDialog()!)
        {
            Application.Current.Shutdown();
        }
    }
}