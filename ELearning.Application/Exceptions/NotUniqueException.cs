using System;

namespace ELearning.Application.Exceptions
{
    public class NotUniqueException : Exception
    {
        public NotUniqueException(string entity, string property1, object value1, string property2, object value2)
            : base($"{entity} with {property1}: {value1} and {property2}: {value2} already exists.")
        {
        }
    }
}
