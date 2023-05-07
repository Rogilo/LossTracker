using DietSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DietSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ration> Rations { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MealDish> MealDishes { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>()
                    .HasKey(pc => new { pc.DishId, pc.IngredientId });
            modelBuilder.Entity<DishIngredient>()
                    .HasOne(p => p.Dish)
                    .WithMany(pc => pc.DishIngredients)
                    .HasForeignKey(p => p.DishId);
            modelBuilder.Entity<DishIngredient>()
                    .HasOne(p => p.Ingredient)
                    .WithMany(pc => pc.DishIngredients)
                    .HasForeignKey(c => c.IngredientId);


            modelBuilder.Entity<MealDish>()
                   .HasKey(pc => new { pc.MealId, pc.DishId });
            modelBuilder.Entity<MealDish>()
                    .HasOne(p => p.Meal)
                    .WithMany(pc => pc.MealDishes)
                    .HasForeignKey(p => p.MealId);
            modelBuilder.Entity<MealDish>()
                    .HasOne(p => p.Dish)
                    .WithMany(pc => pc.MealDishes)
                    .HasForeignKey(c => c.DishId);


            /* modelBuilder.Entity<DishIngredient>()
                 .HasOne(e => e.Ingredient)
                 .WithMany(e => e.DishIngredients)
                 .HasForeignKey(e => e.IngredientId);

             modelBuilder.Entity<DishIngredient>()
                .HasOne(e => e.Dish)
                .WithMany(e => e.DishIngredients)
                .HasForeignKey(e => e.DishId);*/
        }
    }
}
