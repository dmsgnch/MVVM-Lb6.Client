using MVVM_Lb4.StoresControllers;
using MVVM_Lb4.ViewModels.Base;

namespace MVVM_Lb4.ViewModels;

public class HotelViewModel : ViewModel
{
    public GroupsListingViewModel GroupsListingViewModel { get; }
    public GroupsStudentsViewModel GroupsStudentsViewModel { get; }
    

    public HotelViewModel(RequestsSender groupsStore)
    {
        GroupsListingViewModel = new GroupsListingViewModel(this, groupsStore);
        GroupsStudentsViewModel = new GroupsStudentsViewModel(this, groupsStore);
    }
}