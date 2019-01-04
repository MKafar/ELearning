using System;

namespace ELearning.Application.Exceptions
{
    public class NotUniqueException : Exception
    {
        public NotUniqueException(string entity, string property1, int value1, string property2, int value2)
            : base($"{entity} with {property1} equal {value1} and {property2} equal {value2} already exists.")
        {
        }
    }
}
