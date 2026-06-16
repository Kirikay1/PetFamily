using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Shared
{
    public record Requisites
    {
        private Requisites(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; } = default!;

        public string Description { get; } = default!;

        public static Result<Requisites> Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Requisites>("Name cannot be empty");

            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<Requisites>("Description cannot be empty");

            return new Requisites(name, description);
        }
    }
}
