using System;

namespace ELearning.Application.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string user)
            : base($"Password for user {user} is invalid.")
        {
        }
    }
}
