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
                .HasOne(e => e.Ingredient)
                .WithMany(e => e.DishIngredients)
                .HasForeignKey(e => e.IngredientId);

            modelBuilder.Entity<DishIngredient>()
               .HasOne(e => e.Dish)
               .WithMany(e => e.DishIngredients)
               .HasForeignKey(e => e.DishId);

            /*    modelBuilder.Entity<Ingredient>()
                    .HasMany(e => e.Dishes)
                    .WithMany(e => e.Ingredients)
                    .UsingEntity<DishIngredient>();*/

            modelBuilder.Entity<Meal>()
                .HasMany(e => e.Dishes)
                .WithMany(e => e.Meals)
                .UsingEntity<MealDish>();

        }
    }
}
