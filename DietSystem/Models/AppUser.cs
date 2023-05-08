using Microsoft.AspNetCore.Identity;


namespace DietSystem.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfileImageUrl { get; set; }
        public List<Ration> Rations { get; set; }
    }
}
