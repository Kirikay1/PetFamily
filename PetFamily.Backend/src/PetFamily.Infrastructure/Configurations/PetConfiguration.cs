using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;

namespace PetFamily.Infrastructure.Configurations
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pets");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                    id => id.Value,
                    value => PetId.Create(value));

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(Constants.MaxLowTextLength);

            builder.Property(p => p.SpeciesId);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(Constants.MaxHighTextLength);

            builder.Property(p => p.BreedId);

            builder.Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(Constants.MaxLowTextLength);

            builder.Property(p => p.Health)
                .IsRequired()
                .HasMaxLength(Constants.MaxLowTextLength);

            builder.Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(Constants.MaxMediumTextLength);

            builder.Property(p => p.Weight)
                .IsRequired();

            builder.Property(p => p.Height)
                .IsRequired();

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(Constants.MaxLowTextLength);

            builder.Property(p => p.IsCastration)
                .IsRequired();

            builder.Property(p => p.BirthDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.IsVaccination)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasConversion<string>()
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(p => p.Requisites)
                .WithOne()
                .HasForeignKey("petId");

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.HasMany(p => p.Photos)
                .WithOne()
                .HasForeignKey("petId");
        }
    }
}
