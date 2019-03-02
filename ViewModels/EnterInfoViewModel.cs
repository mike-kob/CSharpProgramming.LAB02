using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LAB02.Tools;
using LAB02.Tools.Managers;
using LAB02.Tools.Navigation;

namespace LAB02.ViewModels
{
    class EnterInfoViewModel:BaseViewModel
    {
        #region Fields

        private Person _person;
        private bool _dateChosen = false;

        private RelayCommand<object> _proceedCommand;
        #endregion

        public EnterInfoViewModel()
        {
            _person = new Person("","","");
            StationManager.CurrentPerson = _person;
        }

        #region Properties
        public Person MyPerson
        {
            get { return _person; }
        }

        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(
                           o =>
                           {
                               MessageBox.Show(_person.Name);
                               StationManager.CurrentPerson = _person;
                               NavigationManager.Instance.Navigate(ViewType.ShowInfo);
                           }, CanExecuteProceed));
            }
        }
        #endregion

        private bool CanExecuteProceed(Object obj)
        {
            return
                true; //!String.IsNullOrWhiteSpace(Email) && !String.IsNullOrWhiteSpace(Name) && !String.IsNullOrWhiteSpace(Surname) && _dateChosen;
        }
    }
}
