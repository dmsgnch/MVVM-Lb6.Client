using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_Lb6.Commands.Base;
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

    public LoginCommand(UiUser uiUser)
    {
        _uiUser = uiUser;
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

        HotelViewModel hotelViewModel = new HotelViewModel();
        ICommand command = new ShowWindowCommand<HotelViewModel>(new HotelWindow(), hotelViewModel);
        
        //Loading hotel window
        command.Execute(null);
    }
}