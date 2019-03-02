using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows;
using LAB02.Tools;
using LAB02.Tools.Manager;
using LAB02.Tools.Managers;
using LAB02.Tools.Navigation;

namespace LAB02.ViewModels
{
    class EnterInfoViewModel:BaseViewModel
    {
        #region Fields

        private Person _person;

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
                           ProceedImplementation, CanExecuteProceed));
            }
        }
        #endregion

        private async void ProceedImplementation(object obj)
        {
            LoaderManeger.Instance.ShowLoader();
            bool res = await Task.Run(() => {
                StationManager.CurrentPerson = _person;
                if (!MyPerson.IsCorrectAge)
                {
                    MessageBox.Show("There must be a mistake with your age!");
                    return false;
                };
                if (!new EmailAddressAttribute().IsValid(MyPerson.Email))
                {
                    MessageBox.Show("Your email is not valid");
                    return false;
                }

                if (MyPerson.IsBirthday)
                {
                    MessageBox.Show("Happy Birthday!");

                }
                return true;
            });
            LoaderManeger.Instance.HideLoader();
            if (res)
                NavigationManager.Instance.Navigate(ViewType.ShowInfo);
            }

        private bool CanExecuteProceed(Object obj)
        {
            return !String.IsNullOrWhiteSpace(MyPerson.Email) && !String.IsNullOrWhiteSpace(MyPerson.Name) && !String.IsNullOrWhiteSpace(MyPerson.Surname);
        }
    }
}
