using System.Windows.Input;
using MVVM_Lb6.ViewModels.Base;
using MVVM_Lb6.Commands.LoginRegisterCommands;
using MVVM_Lb6.Commands.MainCommands;
using MVVM_Lb6.UIModels;
using MVVM_Lb6.Views;

namespace MVVM_Lb6.ViewModels;

public class RegistrationViewModel : ViewModel
{
    #region Parameters

    #region Windows
    
    private LoginViewModel LoginViewModel { get;}
    private LoginWindow LoginWindow { get;}
    
    #endregion
    
    #region UiComponents

    public UiUser UiUser { get; set; } = new ();

    #endregion

    #endregion
    
    #region Commands

    public ICommand OpenLoginWindowCommand { get; }
    public ICommand CloseApplicationCommand { get; }
    
    public ICommand RegisterCommand
    {
        get => new RegisterCommand(UiUser);
    }

    #endregion

    public RegistrationViewModel(LoginViewModel loginViewModel)
    {
        LoginViewModel = loginViewModel;
        LoginWindow = new LoginWindow();
        
        OpenLoginWindowCommand = new ShowWindowCommand<LoginViewModel>(LoginWindow, LoginViewModel);
        CloseApplicationCommand = new CloseApplicationCommand();
    }
}