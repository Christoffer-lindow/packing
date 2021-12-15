using System;

namespace PackIT.Shared.Abstractions.Exceptions
{
    public abstract class PackItException : Exception
    {
        public PackItException(string message) : base(message) {}

        protected PackItException()
        {
            throw new NotImplementedException();
        }
    }
}