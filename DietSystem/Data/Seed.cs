using CloudinaryDotNet.Actions;
using DietSystem.Data.Enum;
using DietSystem.Models;
using Microsoft.AspNetCore.Identity;
using RunDietSystem.Data.Enum;
using System.Diagnostics;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace DietSystem.Data
{
    public class Seed
    {
        /*private const double V = 10.4;*/

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Borsch",
                            MethodOfCooking = "Add potatoes with meatballs to boiling salted water (2-3 liters), " +
                            "cook for 20 minutes, then add cabbage, sauteed carrots with onions, " +
                            "borscht dressing with tomato and continue to cook for another 10-15 minutes." +
                            " periodically removing the foam. At the end of cooking, sugar, spices, greens, " +
                            "garlic and sour cream are added to taste.",
                            DishCategory = DishCategory.Soup,
                            Image = "",
                            Calories = 149,
                            Proteins = 5,
                            Fats = 10.4,
                            Carbohydrates = 8.9

                         },

                         new Dish()
                        {
                            Name = "Dumplings with cherry",
                            MethodOfCooking = "Put the frozen dumplings in boiling salted water. " +
                            "Bring to a boil while stirring and cook for 4-5 minutes. Remove the finished dumplings" +
                            " from the water and season to taste (butter, sour cream).",
                            DishCategory = DishCategory.Dumpling,
                            Image = "",
                            Calories = 201,
                            Proteins = 4,
                            Fats = 3.2,
                            Carbohydrates = 39

                         },
                    });
                context.SaveChanges();
            }
            if (!context.Ingredients.Any())
            {
                context.Ingredients.AddRange(new List<Ingredient>()
                {
                        /*Інгрідієнти борщу*/
                        new Ingredient()
                        {
                            Name = "turkey fillet",
                            IngredientCategory = IngredientCategory.MEAT
                        },
                        new Ingredient()
                        {
                            Name = "chicken fillet",
                            IngredientCategory = IngredientCategory.MEAT
                        },
                        new Ingredient()
                        {
                            Name = "lard",
                            IngredientCategory = IngredientCategory.MEAT
                        },
                        new Ingredient()
                        {
                            Name = "onion",
                            IngredientCategory = IngredientCategory.VEGETABLES
                        },
                        new Ingredient()
                        {
                            Name = "sunflower oil",
                            IngredientCategory = IngredientCategory.OILS
                        },
                        new Ingredient()
                        {
                            Name = "carrot",
                            IngredientCategory = IngredientCategory.VEGETABLES
                        },
                        new Ingredient()
                        {
                            Name = "potato",
                            IngredientCategory = IngredientCategory.VEGETABLES
                        },
                        new Ingredient()
                        {
                            Name = "white cabbage",
                            IngredientCategory = IngredientCategory.VEGETABLES
                        },
                        new Ingredient()
                        {
                            Name = "tomato paste",
                            IngredientCategory = IngredientCategory.VEGETABLES
                        },
                        new Ingredient()
                        {
                            Name = "beet",
                            IngredientCategory = IngredientCategory.VEGETABLES
                        },
                        new Ingredient()
                        {
                            Name = "vinegar",
                            IngredientCategory = IngredientCategory.SAUCES
                        },
                        new Ingredient()
                        {
                            Name = "sugar",
                            IngredientCategory = IngredientCategory.SPICES
                        },
                        new Ingredient()
                        {
                            Name = "salt",
                            IngredientCategory = IngredientCategory.SPICES
                        },
                        new Ingredient()
                        {
                            Name = "dill greens",
                            IngredientCategory = IngredientCategory.VEGETABLES
                        },
                        new Ingredient()
                        {
                            Name = "green parsley",
                            IngredientCategory = IngredientCategory.VEGETABLES
                        },
                        /*Інгрідієнти вареників з вишнею*/
                        new Ingredient()
                        {
                            Name = "cherry",
                            IngredientCategory = IngredientCategory.BERRIES
                        },
                        new Ingredient()
                        {
                            Name = "wheat flour",
                            IngredientCategory = IngredientCategory.GRAINS
                        },
                        new Ingredient()
                        {
                            Name = "water",
                            IngredientCategory = IngredientCategory.MISCELLANEOUS
                        },
                        new Ingredient()
                        {
                            Name = "starch",
                            IngredientCategory = IngredientCategory.GRAINS
                        },
                        new Ingredient()
                        {
                            Name = "chicken eggs",
                            IngredientCategory = IngredientCategory.POULTRY
                        }
                    });
                context.SaveChanges();
            }
        }
    }
}

