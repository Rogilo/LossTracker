using System.ComponentModel.DataAnnotations;
using LossTracker.Models;

namespace LossTracker.ViewModels
{
    public class EditLossVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть нову назву втрати")]
        public string? Name { get; set; }

        public int EquipmentTypeId { get; set; }
        public int LossStatusId { get; set; }
        public int ConflictSideId { get; set; }
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Оновіть дату втрати")]
        public DateTime Date { get; set; }

        public List<int> TagIds { get; set; }
        public List<IFormFile>? Photos { get; set; }
    }
}