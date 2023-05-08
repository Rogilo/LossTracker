using System.ComponentModel;
using Microsoft.AspNetCore.Identity;


namespace DietSystem.Models
{
    public class AppUser : IdentityUser
    {
        public const string Image_Default = "https://res.cloudinary.com/dxuyqa9jr/image/upload/v1682499150/samples/animals/cat.jpg";
        public string FullName { get; set; }
        [DefaultValue(Image_Default)]
        public string ProfileImageUrl { get; set; } = Image_Default;
        public List<Ration> Rations { get; set; }
    }
}
