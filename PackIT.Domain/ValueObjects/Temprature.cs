using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects
{
    public record Temprature
    {
        public double Value { get; }

            public Temprature(double value)
            {
                if (value is <-100 or > 100)
                {
                    throw new InvalidTempratureException(value);
                }

                Value = value;
            }

            public static implicit operator double(Temprature degrees)
                => degrees.Value;

            public static implicit operator Temprature(double days)
                => new(days);     
        }
}