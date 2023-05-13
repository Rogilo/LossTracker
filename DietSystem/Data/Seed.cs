using System.Net;
using System.Reflection;
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
                        Name = "Борщ Український",
                        MethodOfCooking = "В киплячу підсолену воду (2-3 л) додають картоплю з фрикадельками, варять протягом 20 хв, потім додати капусту, " +
                        "пасеровану моркву з цибулею, заправку борщову з томатом і продовжують варити ще 10-15 хв. періодично видаляючи піну. " +
                        "Наприкінці варіння додають за смаком цукор, спеції, зелень, часник та сметану.",
                        DishCategory = DishCategory.Суп,
                        Image = "https://res.cloudinary.com/dxuyqa9jr/image/upload/v1683989586/Borsch_up1wgn.jpg",
                        Calories = 149,
                        Proteins = 5,
                        Fats = 10.4,
                        Carbohydrates = 8.9
                    },
                    new Dish()
                    {
                        Name = "Вареники з вишнею",
                        MethodOfCooking = "Заморожені вареники опустити в киплячу підсолену воду. Помішуючи довести до кипіння та варити 4-5 хвилин. " +
                        "Готові вареники вийняти з води та заправити за смаком (маслом, сметаною).",
                        DishCategory = DishCategory.Вареники,
                        Image = "https://res.cloudinary.com/dxuyqa9jr/image/upload/v1683014079/ayrnm1o5ce6mrgpycsrs.jpg",
                        Calories = 201,
                        Proteins = 4,
                        Fats = 3.2,
                        Carbohydrates = 39
                    },
                    new Dish()
                    {
                        Name = "Млинці з м'ясом",
                        MethodOfCooking = "Млинці розморозити при кімнатній температурі та підсмажити на розігрітій соняшникової олії (маслі) на невеликому вогні " +
                        "періодично перевертаючи.",
                        DishCategory = DishCategory.Млинці,
                        Image = "https://res.cloudinary.com/dxuyqa9jr/image/upload/v1682507832/fzuesyuyk7qofzzpsfgg.jpg",
                        Calories = 209,
                        Proteins = 8.9,
                        Fats = 12,
                        Carbohydrates = 16.3
                    },
                    new Dish()
                    {
                        Name = "Торт з сиром, полуницею та шоколадом",
                        MethodOfCooking = "Пиріг бажано розморозити при кімнатній температурі. " +
                        "Випікати при температурі 170°С - 180°С протягом 40-50 хвилин до золотистої скоринки. " +
                        "Після запікання дати постояти при кімнатній температурі 20-30 хвилин.",
                        DishCategory = DishCategory.Пироги,
                        Image = "https://res.cloudinary.com/dxuyqa9jr/image/upload/v1682507983/vpa4ojq017xbvu1ad4bj.webp",
                        Calories = 267,
                        Proteins = 9.3,
                        Fats = 12.6,
                        Carbohydrates = 29
                    },
                    });
            }
                context.SaveChanges();
                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(new List<Ingredient>()
                    {
                        // Інгрідієнти "Борщ Український"
                        new Ingredient()
                        {
                            Name = "філе індика", // id = 1
                            IngredientCategory = IngredientCategory.Мясо
                        },
                        new Ingredient()
                        {
                            Name = "філе куряче", // id = 2
                            IngredientCategory = IngredientCategory.Мясо
                        },
                        new Ingredient()
                        {
                            Name = "сало свинне", // id = 3
                            IngredientCategory = IngredientCategory.Мясо
                        },
                        new Ingredient()
                        {
                            Name = "цибуля ріпчаста", // id = 4
                            IngredientCategory = IngredientCategory.Овочі
                        },
                        new Ingredient()
                        {
                            Name = "олія соняшникова", // id = 5
                            IngredientCategory = IngredientCategory.Масла
                        },
                        new Ingredient()
                        {
                            Name = "морква", // id = 6
                            IngredientCategory = IngredientCategory.Овочі
                        },
                        new Ingredient()
                        {
                            Name = "картопля", // id = 7
                            IngredientCategory = IngredientCategory.Овочі
                        },
                        new Ingredient()
                        {
                            Name = "капуста білокачанна", // id = 8
                            IngredientCategory = IngredientCategory.Овочі
                        },
                        new Ingredient()
                        {
                            Name = "паста томатна", // id = 9
                            IngredientCategory = IngredientCategory.Овочі
                        },
                        new Ingredient()
                        {
                            Name = "буряк", // id = 10
                            IngredientCategory = IngredientCategory.Овочі
                        },
                        new Ingredient()
                        {
                            Name = "оцет 9%", // id = 11
                            IngredientCategory = IngredientCategory.Соуси
                        },
                        new Ingredient() 
                        {
                            Name = "цукор", // id = 12
                            IngredientCategory = IngredientCategory.Спеції
                        },
                        new Ingredient()
                        {
                            Name = "сіль", // id = 13
                            IngredientCategory = IngredientCategory.Спеції
                        },
                        new Ingredient()
                        {
                            Name = "кріп", // id = 14
                            IngredientCategory = IngredientCategory.Овочі
                        },
                        new Ingredient()
                        {
                            Name = "петрушка", // id = 15
                            IngredientCategory = IngredientCategory.Овочі
                        },
                        // Інгрідієнти "Вареники з вишнею"
                        new Ingredient()
                        {
                            Name = "вишня", // id = 16
                            IngredientCategory = IngredientCategory.Ягоди
                        },
                        new Ingredient()
                        {
                            Name = "борошно пшеничне", // id = 17
                            IngredientCategory = IngredientCategory.Зерна
                        },
                        new Ingredient()
                        {
                            Name = "вода", // id = 18
                            IngredientCategory = IngredientCategory.Напої
                        },
                        new Ingredient()
                        {
                            Name = "крохмаль", // id = 19
                            IngredientCategory = IngredientCategory.Зерна
                        },
                        new Ingredient()
                        {
                            Name = "яйця курячі", // id = 20
                            IngredientCategory = IngredientCategory.Птиця
                        },
                        // Інгрідієнти "Торт з сиром, полуницею та шоколадом"
                        new Ingredient()
                        {
                            Name = "сир кисломолочний", // id = 21
                            IngredientCategory = IngredientCategory.Молочний
                        },
                        new Ingredient()
                        {
                            Name = "полуниця", // id = 22
                            IngredientCategory = IngredientCategory.Ягоди
                        },
                        new Ingredient()
                        {
                            Name = "шоколад молочний", // id = 23
                            IngredientCategory = IngredientCategory.Підсолоджувачі
                        },
                        new Ingredient()
                        {
                            Name = "масло вершкове,", // id = 24
                            IngredientCategory = IngredientCategory.Молочний
                        },
                        new Ingredient()
                        {
                            Name = "крупа манна", // id = 25
                            IngredientCategory = IngredientCategory.Зерна
                        },
                        new Ingredient()
                        {
                            Name = "какао-порошок", // id = 26
                            IngredientCategory = IngredientCategory.Підсолоджувачі
                        },
                        new Ingredient()
                        {
                            Name = "ванільний цукор.", // id = 27
                            IngredientCategory = IngredientCategory.Підсолоджувачі
                        },
                        new Ingredient()
                        {
                            Name = "сода харчова", // id = 28
                            IngredientCategory = IngredientCategory.Спеції
                        }, 
                        // Інгрідієнти "Млинці з м'ясом"
                        new Ingredient()
                        {
                            Name = "молоко коров'яче", // id = 29
                            IngredientCategory = IngredientCategory.Молочний
                        },
                        new Ingredient()
                        {
                            Name = "свинина знежилована", // id = 30
                            IngredientCategory = IngredientCategory.Мясо
                        },      
                        new Ingredient()
                        {
                            Name = "перець чорний ", // id = 31
                            IngredientCategory = IngredientCategory.Спеції
                        }
                    });
                }
                context.SaveChanges();
            if (!context.DishIngredients.Any())
            {
                context.DishIngredients.AddRange(new List<DishIngredient>()
                        {
                            // Табличка страви-інгрідієнти "Борщ Український"       
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
                            // Табличка страви-інгрідієнти "Вареники з вишнею"
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
                            },
                            // Табличка страви-інгрідієнти "Вареники з вишнею"\
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 21,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 22,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 23,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 24,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 25,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 26,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 27,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 28,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 12,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 13,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 17,
                            },
                            new DishIngredient
                            {
                                DishId = 3,
                                IngredientId = 20,
                            },
                            // Табличка страви-інгрідієнти "Млинці з м'ясом"
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 29,
                            },
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 30,
                            },
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 31,
                            },    
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 12,
                            },
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 13,
                            },
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 4,
                            },  
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 17,
                            },  
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 20,
                            },
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 18,
                            },  
                            new DishIngredient
                            {
                                DishId = 4,
                                IngredientId = 24,
                            },
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
