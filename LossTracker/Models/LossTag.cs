using System.ComponentModel.DataAnnotations;

namespace LossTracker.Models
{
    public class LossTag
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }

        // Зв'язок багато до багатьох
        public List<Loss> Losses { get; set; }
    }
}
