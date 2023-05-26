using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_lb6.Domain.Requests;
using MVVM_Lb6.HttpsClient;
using MVVM_Lb6.UIModels;

namespace MVVM_Lb6.Commands.LoginRegisterCommands;

internal class RegisterCommand : AsyncCommandBase
{
    private readonly UiUser _uiUser;

    public RegisterCommand(UiUser uiUser)
    {
        _uiUser = uiUser;
    }
    public override bool CanExecute(object parameter) => true;

    public override async Task ExecuteAsync(object parameter)
    {
        UIValidator uiValidator = new UIValidator();
        if (!await uiValidator.IsValidAllUserUIParamsAsync(_uiUser)) return;

        RegistrationRequest registrationRequest = new RegistrationRequest()
        {
            Username = _uiUser.Username,
            IndividualEmployeeNumber = _uiUser.IndividualEmployeeNumber,
            Password = _uiUser.Password
        };

        await WebRequestsController.RegisterRequestAsync(registrationRequest);
    }
}