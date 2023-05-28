using System.Data;
using System.Windows;
using System.Windows.Input;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.ViewModels.Base;
using MVVM_Lb6.Commands.LoginRegisterCommands;
using MVVM_Lb6.Commands.MainCommands;
using MVVM_Lb6.UIModels;
using MVVM_Lb6.Views;

namespace MVVM_Lb6.ViewModels;

public class LoginViewModel : ViewModel
{
    #region Parameters

    #region Windows

    private RegistrationViewModel RegistrationViewModel
    {
        get => new RegistrationViewModel(this);
    }
    private RegistrationWindow RegistrationWindow
    {
        get => new RegistrationWindow();
    }

    #endregion
    
    #region UiComponents

    public UiUser UiUser { get; set; } = new ();

    #endregion

    #endregion
    
    #region Commands

    public ICommand OpenRegisterWindowCommand
    {
        get => new ShowWindowCommand<RegistrationViewModel>(RegistrationWindow, RegistrationViewModel);
    }
    public ICommand CloseApplicationCommand { get; }

    public ICommand LoginCommand
    {
        get => new LoginCommand(UiUser);
    }

    #endregion

    public LoginViewModel()
    {
        CloseApplicationCommand = new CloseApplicationCommand();
    }
}