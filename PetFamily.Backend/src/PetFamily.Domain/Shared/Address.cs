using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared
{
    public record Address
    {
        public string Value { get; }

        private Address(string value)
        {
            Value = value;
        }

        public static Result<Address> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return Result.Failure<Address>("Address cannot be empty");

            return new Address(value);
        }
    }
}
