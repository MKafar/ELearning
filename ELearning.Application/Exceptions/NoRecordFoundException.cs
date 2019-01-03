using System;

namespace ELearning.Application.Exceptions
{
    public class NoRecordFoundException : Exception
    {
        public NoRecordFoundException(string entity, string fieldName, object key, string message)
            : base($"Query to entity \"{entity}\" by \"{fieldName}\": ({key}) returns no record. {message}")
        {
        }
    }
}
