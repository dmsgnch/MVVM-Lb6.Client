using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb6.ViewModels.Base;
using MVVM_Lb6.Views;

namespace MVVM_Lb6.Commands.MainCommands;

public class ShowWindowCommand<T> : CommandBase 
    where T : ViewModel
{
    private readonly Window _window;
    private readonly T _viewModel;

    public ShowWindowCommand(Window window, T viewModel)
    {
        _window = window;
        _viewModel = viewModel;
    }
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter)
    {
        Application.Current.MainWindow?.Close();

        Application.Current.MainWindow = _window;
        _window.Show();
        _window.DataContext = _viewModel;
    }
}