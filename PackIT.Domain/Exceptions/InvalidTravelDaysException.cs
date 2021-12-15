using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class InvalidTravelDaysException : PackItException
    {
        public ushort Days { get; }

        public InvalidTravelDaysException(ushort days) : base($"{days} is too long or too short")
            => Days = days;
    }
}