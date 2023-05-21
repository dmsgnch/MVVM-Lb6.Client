using System.Collections.Generic;
using System.Windows.Input;
using MVVM_Lb4.Commands;
using MVVM_Lb4.Domain.Models;
using MVVM_Lb4.StoresControllers;
using MVVM_Lb4.UIModels;
using MVVM_Lb4.ViewModels.Base;

namespace MVVM_Lb4.ViewModels
{
    public class GroupsListingViewModel : ViewModel
    {
        
        #region ViewGroupList
        
        private List<Group> _groupsView =
            new List<Group>();

        public List<Group> GroupsView
        {
            get => _groupsView;
            set => Set(ref _groupsView, value);
        }
        
        #endregion
        
        #region Params
        
        private RequestsSender _groupsStore { get; }
        private HotelViewModel HotelViewModel { get; }
        
        #region SelectedGroup

        private Group? _selectedGroup = null;

        public Group? SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                Set(ref _selectedGroup, value);
                bool isSelected = _selectedGroup is not null;
                
                HotelViewModel.GroupsStudentsViewModel.GroupIsSelected = isSelected;
                GroupIsSelected = isSelected;
                
                HotelViewModel.GroupsStudentsViewModel.GetStudentsList();
            }
        }
        
        #endregion
        
        #region GroupIsSelected
        
        private bool _groupIsSelected = false;
        public bool GroupIsSelected
        {
            get => _groupIsSelected; 
            set => Set(ref _groupIsSelected, value); 
        }

        #endregion
        
        #region AddGroup

        private UIGroup _uiGroup = new();

        public UIGroup UiGroup
        {
            get => _uiGroup;
            set => Set(ref _uiGroup, value);
        }

        #endregion

        #endregion

        #region Commands
        
        public ICommand AddGroupCommand { get; }
        public ICommand DeleteGroupCommand { get; }
        public ICommand EditGroupCommand { get; }
        
        #endregion

        public GroupsListingViewModel(HotelViewModel hotelViewModel, RequestsSender groupsStore)
        {
            _groupsStore = groupsStore;
            HotelViewModel = hotelViewModel;

            LoadGroups();

            AddGroupCommand = new AddGroupCommand(groupsStore, this);
            DeleteGroupCommand = new DeleteGroupCommand(groupsStore, this);
            EditGroupCommand = new EditGroupCommand(groupsStore, this);
        }

        public async void LoadGroups()
        {
            GroupsView = await _groupsStore.LoadGroupsAsync();
        }
    }
}