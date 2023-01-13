using Application.Common.Utilities;

namespace Infrastructure.Persistence.Configurations
{
    public class StrenghtConfiguration : IEntityTypeConfiguration<Strenght>
    {
        private Guid guidUser = new Guid("af855ff4-c3e3-4a5e-a5a8-6874bd2f7a31");
        public void Configure(EntityTypeBuilder<Strenght> builder)
        {
            builder.Property(s => s.Name).HasColumnType("nvarchar(100)");

            builder.HasMany(s => s.MostWinsDuringTheDay)
                   .WithOne(s => s.Strenght)
                   .HasForeignKey(s => s.StrenghtId);
            //"CreatedBy", "CreatedDate", "InactivatedBy", "InactivatedDate", "ModifiedBy", "ModifiedDate"
            builder.HasData(
                new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.Responsibility),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Responsibility"
                },
                new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.Achiever),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Achiever"
                },
                new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.Focus),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Focus"
                },
                new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.Learner),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Learner"
                },
                new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.Individualization),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Individualization"
                },
                new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.SelfAssurance),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Self-Assurance"
                },
                new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.Activator),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Activator"
                },
                new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.Futuristic),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Futuristic"
                }, new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.Connectedness),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Connectedness"
                }, new Strenght()
                {
                    Id = new Guid(UtilitiesStrenght.Relator),
                    CreatedBy = guidUser,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = guidUser,
                    ModifiedDate = DateTime.Now,
                    Name = "Relator"
                });
        }
    }
}
