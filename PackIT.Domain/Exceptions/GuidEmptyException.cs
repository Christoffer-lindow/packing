using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class GuidEmptyException : PackItException
    {
        public GuidEmptyException(): base("Guid was empty")
        {
            
        }
    }
}