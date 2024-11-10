using LossTracker.Data.Enums;
using LossTracker.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LossTracker.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            // Seed Equipment Types
            if (!context.EquipmentTypes.Any())
            {
                context.EquipmentTypes.AddRange(new List<EquipmentType>()
                {
                    new EquipmentType()
                    {
                        Name = "Tank"
                    },
                    new EquipmentType()
                    {
                        Name = "BMP"
                    },
                    new EquipmentType()
                    {
                        Name = "Artillery"
                    },
                    new EquipmentType()
                    {
                        Name = "Self Propelled Artillery"
                    }
                });
            }

            // Seed Loss Statuses
            if (!context.LossStatuses.Any())
            {
                context.LossStatuses.AddRange(new List<LossStatus>()
                {
                    new LossStatus()
                    {
                        Name = "Destroyed"
                    },
                    new LossStatus()
                    {
                        Name = "Captured"
                    },
                    new LossStatus()
                    {
                        Name = "Abandoned"
                    }
                });
            }

            // Seed Tags
            if (!context.LossTags.Any())
            {
                context.LossTags.AddRange(new List<LossTag>()
                {
                    new LossTag()
                    {
                        TagName = "Turret Grill"
                    },
                    new LossTag()
                    {
                        TagName = "Tactical Symbol"
                    },
                    new LossTag()
                    {
                        TagName = "Mine Roller"
                    }
                });
            }

            // Seed Photos
            if (!context.Photos.Any())
            {
                context.Photos.AddRange(new List<Photo>()
                {
                    new Photo()
                    {
                        Url = "https://example.com/T72.jpg",
                        Description = "Т-72",
                        LossId = 1
                    },
                    new Photo()
                    {
                        Url = "https://example.com/BMP.jpg",
                        Description = "BMP-2",
                        LossId = 2
                    },
                    new Photo()
                    {
                        Url = "https://example.com/Ka52.jpg",
                        Description = "Ka-52",
                        LossId = 3
                    }
                });
            }

            context.SaveChanges();
        }
    }
}
