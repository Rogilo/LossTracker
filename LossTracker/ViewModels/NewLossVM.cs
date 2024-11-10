using System.ComponentModel.DataAnnotations;

namespace LossTracker.ViewModel
{
    public class NewLossVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть назву втрати")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Виберіть тип техніки")]
        public int EquipmentTypeId { get; set; }

        [Required(ErrorMessage = "Виберіть статус втрати")]
        public int LossStatusId { get; set; }

        [Required(ErrorMessage = "Виберіть сторону конфлікту")]
        public int ConflictSideId { get; set; }

        [Required(ErrorMessage = "Виберіть локацію")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Введіть дату втрати")]
        public DateTime Date { get; set; }

        // URL фотографії, що представляє втрату
        public string? URL { get; set; }

        // Фото втрати
        [Required(ErrorMessage = "Виберіть фото втрати")]
        public List<IFormFile>? Photos { get; set; }

        // Теги
        [Required(ErrorMessage = "Виберіть теги втрати")]
        public List<int> TagIds { get; set; }
    }
}
