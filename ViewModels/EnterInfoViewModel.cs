using System;
using System.Threading.Tasks;
using System.Windows;
using LAB02.Tools;
using LAB02.Tools.Exceptions;
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

                try
                {
                    StationManager.CurrentPerson.ValidatePerson();
                }
                catch (PersonNotBornException e)
                {
                    MessageBox.Show($"Mistake with age: {e.Message}");
                    return false;
                }
                catch (PersonTooOldException e)
                {
                    MessageBox.Show($"Mistake with age: {e.Message}");
                    return false;
                }
                catch (InvalidEmailException e)
                {
                    MessageBox.Show($"Mistake with email: {e.Message}");
                    return false;
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
