using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using MVVM_Lb4.Commands.Base;
using MVVM_Lb6.UIModels;

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
        
        //TODO: sending request to the server

        // if (_groupsListingViewModel.GroupsView.Any(g => g.GroupName.Equals(_groupsListingViewModel.UiGroup.GroupName)))
        // {
        //     MessageBox.Show("A group with the same name already exists!", "Group name error", 
        //         MessageBoxButton.OK, MessageBoxImage.Error);
        // }
        // else
        // {
        //     await _store.AddGroupToDbAsync(new Group(_groupsListingViewModel.UiGroup.GroupName));
        //     _groupsListingViewModel.LoadGroups();
        //
        //     MessageBox.Show($"A group called {_groupsListingViewModel.UiGroup.GroupName} has been successfully created", "Success action", 
        //         MessageBoxButton.OK, MessageBoxImage.Information);
        // }
    }
}