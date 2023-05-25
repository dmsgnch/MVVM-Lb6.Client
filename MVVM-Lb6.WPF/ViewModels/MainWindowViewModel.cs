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
	
	// public LoginViewModel LoginViewModel
	// {
	// 	get => new LoginViewModel();
	// }

	public MainWindowViewModel()
	{
		#region Commands

		CloseApplicationCommand =
			new CloseApplicationCommand();

		#endregion Commands
	}
}