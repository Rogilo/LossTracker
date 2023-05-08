using System.Net;
using DietSystem.Data.Enum;
using DietSystem.Models;
using Microsoft.AspNetCore.Identity;
using RunDietSystem.Data.Enum;

namespace DietSystem.Data
{
    public class Seed
    {
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
                        Image = "https://res.cloudinary.com/dxuyqa9jr/image/upload/v1683193622/vwnkjfspsj9l1wlhni5x.jpg",
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
                        Image = "https://res.cloudinary.com/dxuyqa9jr/image/upload/v1683014079/ayrnm1o5ce6mrgpycsrs.jpg",
                        Calories = 201,
                        Proteins = 4,
                        Fats = 3.2,
                        Carbohydrates = 39
                    }
                    });
            }
                context.SaveChanges();
                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(new List<Ingredient>()
                    {
                        // Інгрідієнти "Borsch"
                        new Ingredient()
                        {
                            Name = "turkey fillet",
                            IngredientCategory = IngredientCategory.Meat
                        },
                        new Ingredient()
                        {
                            Name = "chicken fillet",
                            IngredientCategory = IngredientCategory.Meat
                        },
                        new Ingredient()
                        {
                            Name = "lard",
                            IngredientCategory = IngredientCategory.Meat
                        },
                        new Ingredient()
                        {
                            Name = "onion",
                            IngredientCategory = IngredientCategory.Vegetables
                        },
                        new Ingredient()
                        {
                            Name = "sunflower oil",
                            IngredientCategory = IngredientCategory.Oils
                        },
                        new Ingredient()
                        {
                            Name = "carrot",
                            IngredientCategory = IngredientCategory.Vegetables
                        },
                        new Ingredient()
                        {
                            Name = "potato",
                            IngredientCategory = IngredientCategory.Vegetables
                        },
                        new Ingredient()
                        {
                            Name = "white cabbage",
                            IngredientCategory = IngredientCategory.Vegetables
                        },
                        new Ingredient()
                        {
                            Name = "tomato paste",
                            IngredientCategory = IngredientCategory.Vegetables
                        },
                        new Ingredient()
                        {
                            Name = "beet",
                            IngredientCategory = IngredientCategory.Vegetables
                        },
                        new Ingredient()
                        {
                            Name = "vinegar",
                            IngredientCategory = IngredientCategory.Sauces
                        },
                        new Ingredient() // id = 12
                        {
                            Name = "sugar",
                            IngredientCategory = IngredientCategory.Spices
                        },
                        new Ingredient() // id = 13
                        {
                            Name = "salt",
                            IngredientCategory = IngredientCategory.Spices
                        },
                        new Ingredient()
                        {
                            Name = "dill greens",
                            IngredientCategory = IngredientCategory.Vegetables
                        },
                        new Ingredient()
                        {
                            Name = "green parsley",
                            IngredientCategory = IngredientCategory.Vegetables
                        },
                        // Інгрідієнти "Dumplings with cherry"
                        new Ingredient()
                        {
                            Name = "cherry",
                            IngredientCategory = IngredientCategory.Berries
                        },
                        new Ingredient()
                        {
                            Name = "wheat flour",
                            IngredientCategory = IngredientCategory.Grains
                        },
                        new Ingredient()
                        {
                            Name = "water",
                            IngredientCategory = IngredientCategory.Miscellaneous
                        },
                        new Ingredient()
                        {
                            Name = "starch",
                            IngredientCategory = IngredientCategory.Grains
                        },
                        new Ingredient()
                        {
                            Name = "chicken eggs",
                            IngredientCategory = IngredientCategory.Poultry
                        }
                    });
                }
                context.SaveChanges();
            if (!context.DishIngredients.Any())
            {
                context.DishIngredients.AddRange(new List<DishIngredient>()
                        {
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 1,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 2,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 3,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 4,
                            },
                              new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 5,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 6,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 7,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 8,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 9,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 10,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 11,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 12,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 13,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 14,
                            },
                            new DishIngredient
                            {
                                DishId = 1,
                                IngredientId = 15,
                            },
                            new DishIngredient
                            {
                                DishId = 2,
                                IngredientId = 16,
                            },
                            new DishIngredient
                            {
                                DishId = 2,
                                IngredientId = 17,
                            },
                            new DishIngredient
                            {
                                DishId = 2,
                                IngredientId = 18,
                            },
                            new DishIngredient
                            {
                                DishId = 2,
                                IngredientId = 19,
                            },
                            new DishIngredient
                            {
                                DishId = 2,
                                IngredientId = 20,
                            },
                            new DishIngredient
                            {
                                DishId = 2,
                                IngredientId = 12,
                            },
                            new DishIngredient
                            {
                                DishId = 2,
                                IngredientId = 13,
                            }
                        });
                context.SaveChanges();
            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "admin@dietSystem.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        ProfileImageUrl = "https://res.cloudinary.com/dxuyqa9jr/image/upload/v1682499170/cld-sample.jpg",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@dietSystem.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        ProfileImageUrl = "https://res.cloudinary.com/dxuyqa9jr/image/upload/v1682499152/samples/people/smiling-man.jpg",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
