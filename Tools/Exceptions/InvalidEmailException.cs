using System;

namespace LAB02.Tools.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email)
            : base($"Invalid email address: {email}")

        {
        }
    }
}
