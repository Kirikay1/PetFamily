namespace PetFamily.Domain.Pet
{
    public class Pet
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public Guid SpeciesId { get; set; }

        public string Description { get; set; } = default!;

        public string Breed { get; set; } = default!;

        public string Color { get; set; } = default!;
         
        public string Health { get; set; } = default!;

        public string Address { get; set; } = default!;

        public int Weight { get; set; } = default;

        public int Height { get; set; } = default;

        public string Phone { get; set; } = default!;

        public bool IsCastration { get; set; } = default;

        public DateTime BirthDate { get; set; } = default;
    
        public bool IsVaccination { get; set; } = default;

        public string Status { get; set; } = default!;

        public Guid RequisitesId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
