using System;
using LAB02.Tools;
using LAB02.Tools.Managers;
using LAB02.Tools.Navigation;

namespace LAB02.ViewModels
{
    class ShowInfoViewModel : BaseViewModel
    {
        #region Fields

        private Person _person = StationManager.CurrentPerson;
        private RelayCommand<object> _backCommand;

        #endregion

        public Person MyPerson
        {
            get { return _person; }
        }

        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(
                           o => { NavigationManager.Instance.Navigate(ViewType.EnterInfo); }));
            }
        }
    }
}