using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB02.Tools;
using LAB02.Tools.Managers;
using LAB02.Tools.Navigation;

namespace LAB02.ViewModels
{
    class ShowInfoViewModel: BaseViewModel
    {
        #region Fields

        private Person _person = StationManager.CurrentPerson;

        #endregion

        public Person MyPerson
        {
            get { return _person; }
        }

        private RelayCommand<object> _backCommand;

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