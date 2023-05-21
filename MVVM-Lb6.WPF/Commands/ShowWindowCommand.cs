using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb6.Views;

namespace MVVM_Lb6.Commands;

public class ShowWindowCommand : CommandBase
{
    private readonly Window _window;

    public ShowWindowCommand(Window window)
    {
        _window = window;
    }
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter)
    {
        Application.Current.MainWindow?.Close();
        
        _window.Show();
    }
}