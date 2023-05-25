using System.Windows.Input;
using MVVM_Lb6.ViewModels.Base;
using MVVM_Lb6.Commands.MainCommands;

namespace MVVM_Lb6.ViewModels;

internal class MainWindowViewModel : ViewModel
{
	#region Commands

	#region CloseApp
	public ICommand CloseApplicationCommand { get; }

	#endregion CloseApp

	#endregion Commands
	
	public LoginViewModel LoginViewModel { get; }

	public MainWindowViewModel(LoginViewModel loginViewModel)
	{
		#region Commands

		CloseApplicationCommand =
			new CloseApplicationCommand();

		#endregion Commands

		LoginViewModel = loginViewModel;
	}
}