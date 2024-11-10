using Microsoft.EntityFrameworkCore;
using LossTracker.Models;

namespace LossTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Loss> Losses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<LossStatus> LossStatuses { get; set; }
        public DbSet<ConflictSide> ConflictSides { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<LossTag> LossTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Зв'язок між Loss і Photo (Композиція)
            modelBuilder.Entity<Loss>()
                .HasMany(l => l.Photos)
                .WithOne()
                .HasForeignKey(p => p.LossId)
                .OnDelete(DeleteBehavior.Cascade);

            // Зв'язок між Loss і LossTag (Агрегація, багато-до-багатьох)
            modelBuilder.Entity<LossTag>()
                .HasMany(lt => lt.Losses)
                .WithMany(l => l.Tags)
                .UsingEntity(j => j.ToTable("LossTags"));
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
