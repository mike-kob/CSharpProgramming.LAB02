﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using LAB02.Tools.Exceptions;

namespace LAB02
{
    class Person : INotifyPropertyChanged
    {
        #region Fields

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string BirthdayString
        {
            get { return _birthday.ToShortDateString(); }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = Convert.ToDateTime(value);
                OnPropertyChanged();
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("IsBirthday");
                OnPropertyChanged("BirthdayString");
                OnPropertyChanged("SunSign");
                OnPropertyChanged("ChineseSign");
            }
        }

        #endregion

        #region Constructors

        public Person(string name, string surname, string email, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = birthday;
        }

        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        public Person(string name, string surname, DateTime
            birthday)
        {
            _name = name;
            _surname = surname;
            _birthday = birthday;
        }

        #endregion

        #region ReadOnlyProps

        private int Age
        {
            get
            {
                int years = DateTime.Today.Year - _birthday.Year;
                if (DateTime.Today.Month < _birthday.Month)
                {
                    years--;
                }
                else if (DateTime.Today.Month == _birthday.Month)
                {
                    if (DateTime.Today.Day < _birthday.Day)
                    {
                        years--;
                    }
                }

                return years;
            }
        }

        public bool IsAdult
        {
            get { return Age >= 18; }
        }

        public string SunSign
        {
            get
            {
                switch (_birthday.Month)
                {
                    case 1:
                        return (_birthday.Day < 20) ? "Capricorn" : "Aquarius";
                    case 2:
                        return (_birthday.Day < 19) ? "Aquarius" : "Pisces";
                    case 3:
                        return (_birthday.Day < 21) ? "Pisces" : "Aries";
                    case 4:
                        return (_birthday.Day < 20) ? "Aries" : "Taurus";
                    case 5:
                        return (_birthday.Day < 21) ? "Taurus" : "Gemini";
                    case 6:
                        return (_birthday.Day < 21) ? "Gemini" : "Cancer";
                    case 7:
                        return (_birthday.Day < 23) ? "Cancer" : "Leo";
                    case 8:
                        return (_birthday.Day < 23) ? "Leo" : "Virgo";
                    case 9:
                        return (_birthday.Day < 23) ? "Virgo" : "Libra";
                    case 10:
                        return (_birthday.Day < 23) ? "Libra" : "Scorpio";
                    case 11:
                        return (_birthday.Day < 22) ? "Scorpio" : "Sagittarius";
                    default:
                        return (_birthday.Day < 22) ? "Sagittarius" : "Capricorn";
                }
            }
        }

        public string ChineseSign
        {
            get
            {
                switch (_birthday.Year % 12)
                {
                    case 0: return "Monkey";
                    case 1: return "Rooster";
                    case 2: return "Dog";
                    case 3: return "Pig";
                    case 4: return "Rat";
                    case 5: return "Ox";
                    case 6: return "Tiger";
                    case 7: return "Rabbit";
                    case 8: return "Dragon";
                    case 9: return "Snake";
                    case 10: return "Horse";
                    default: return "Goat";
                }
            }
        }

        public bool IsBirthday
        {
            get { return (_birthday.Day == DateTime.Today.Day) && (_birthday.Month == DateTime.Today.Month); }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public void ValidatePerson()
        {
            if (Age < 0)
            {
                throw new PersonNotBornException();
            }

            if (Age > 135)
            {
                throw new PersonTooOldException();
            }

            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailRegex.IsMatch(_email))
            {
                throw new InvalidEmailException(_email);
            }

            
        }
    }
}