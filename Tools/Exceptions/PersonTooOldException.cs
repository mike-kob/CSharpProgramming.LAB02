using System;

namespace LAB02.Tools.Exceptions
{
    class PersonTooOldException : Exception
    {
        public PersonTooOldException() : base("Peron can't be over 135 years old")
        {
        }
    }
}
