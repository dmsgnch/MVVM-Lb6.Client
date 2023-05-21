using System.Data;
using System.Windows;
using System.Windows.Input;
using MVVM_Lb6.Commands;
using MVVM_Lb6.Views;

namespace MVVM_Lb4.ViewModels;

public class LoginViewModel
{
    #region Commands

    public ICommand OpenRegisterWindowCommand { get; }

    #endregion

    public LoginViewModel()
    {
        OpenRegisterWindowCommand = new ShowWindowCommand(new RegistrationWindow());
    }
}