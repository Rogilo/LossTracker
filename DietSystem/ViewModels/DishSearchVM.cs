using DietSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DietSystem.ViewModels
{
    public class DishSearchVM
    {
        public List<Dish>? Dishes { get; set; }
        public SelectList? Category { get; set; }
        public string? DishCategory { get; set; }
        public string? SearchString { get; set; }
    }
}
