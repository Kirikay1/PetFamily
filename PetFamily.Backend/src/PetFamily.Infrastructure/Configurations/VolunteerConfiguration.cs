using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Pets;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infrastructure.Configurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
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

            builder.Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(Constants.MaxHighTextLength);

            builder.Property(v => v.Experience)
                .IsRequired();

            builder.Property(v => v.Phone)
                .IsRequired()
                .HasMaxLength(Constants.MaxLowTextLength);

            builder.OwnsOne(v => v.SocialNetworkDetails, vb =>
            {
                vb.ToJson();

                vb.OwnsMany(d => d.SocialNetworks, snb =>
                {
                    snb.Property(sn => sn.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MaxLowTextLength);

                    snb.Property(sn => sn.Link)
                    .IsRequired()
                    .HasMaxLength(Constants.MaxMediumTextLength);
                });
            });

            builder.OwnsOne(v => v.RequisitesDetails, vb =>
            {
                vb.ToJson();

                vb.OwnsMany(d => d.Requisites, rb =>
                {
                    rb.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MaxMediumTextLength);

                    rb.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MaxHighTextLength);
                });
            });

            builder.HasMany(p => p.Pets)
                .WithOne()
                .HasForeignKey("volunteer_id");
        }
    }
}
