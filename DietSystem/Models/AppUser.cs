using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace DietSystem.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
