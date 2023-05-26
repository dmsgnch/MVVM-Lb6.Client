using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb6.Commands.MainCommands;
using MVVM_lb6.Domain.Requests;
using MVVM_Lb6.HttpsClient;
using MVVM_Lb6.UIModels;
using MVVM_Lb6.ViewModels;
using MVVM_Lb6.Views;

namespace MVVM_Lb6.Commands.LoginRegisterCommands;

internal class LoginCommand : AsyncCommandBase
{
    private readonly UiUser _uiUser;
    private readonly ICommand _command;

    public LoginCommand(UiUser uiUser, ICommand command)
    {
        _uiUser = uiUser;
        _command = command;
    }
    public override bool CanExecute(object parameter) => true;

    public override async Task ExecuteAsync(object parameter)
    {
        UIValidator uiValidator = new UIValidator();
        if (!await uiValidator.IsValidMainUserUIParamsAsync(_uiUser)) return;
        
        LoginRequest loginRequest = new LoginRequest()
        {
            IEN = _uiUser.IndividualEmployeeNumber,
            Password = _uiUser.Password
        };

        await WebRequestsController.LoginRequestAsync(loginRequest);

        //Loading hotel window
        _command.Execute(null);
    }
}