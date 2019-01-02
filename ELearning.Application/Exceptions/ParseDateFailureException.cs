using System;

namespace ELearning.Application.Exceptions
{
    public class ParseDateFailureException : Exception
    {
        public ParseDateFailureException(string date)
            :base ($"Parsing of date {date} was not successful.")
        {
        }
    }
}
