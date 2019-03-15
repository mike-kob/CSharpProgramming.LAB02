using System;

namespace LAB02.Tools.Exceptions
{
    class PersonNotBornException : Exception
    {
        public PersonNotBornException() : base("Person is not born yet")
        {
        }
    }
}
