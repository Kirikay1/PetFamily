using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infrastructure.Configurations
{
    internal class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("volunteers");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasConversion(
                    id => id.Value,
                    value => VolunteerId.Create(value));

            builder.Property(v => v.FullName)
                .IsRequired()
                .HasMaxLength(Constants.MaxLowTextLength);

            builder.Property(v => v.Email)
                .IsRequired()
                .HasMaxLength(Constants.MaxLowTextLength);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(Constants.MaxHighTextLength);

            builder.Property(p => p.Experience)
                .IsRequired();

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(Constants.MaxLowTextLength);

            builder.HasMany(p => p.SocialNetworks)
                .WithOne()
                .HasForeignKey("volunteerId");

            builder.HasMany(p => p.Requisites)
                .WithOne()
                .HasForeignKey("volunteerId");

            builder.HasMany(p => p.Pets)
                .WithOne()
                .HasForeignKey("volunteerId");
        }
    }
}
