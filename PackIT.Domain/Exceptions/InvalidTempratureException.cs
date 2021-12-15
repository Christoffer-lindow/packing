using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class InvalidTempratureException : PackItException
    {
        public double Temprature { get; }

        public InvalidTempratureException(double temprature): base($"{temprature} is not a valid Temprature")
            => Temprature = temprature;
    }
}