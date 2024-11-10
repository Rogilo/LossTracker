using System.ComponentModel.DataAnnotations;

namespace LossTracker.ViewModels
{
    public class LossSearchVM
    {
        [Display(Name = "Назва втрати")]
        public string? Name { get; set; }

        [Display(Name = "Тип техніки")]
        public int? EquipmentTypeId { get; set; }

        [Display(Name = "Статус втрати")]
        public int? LossStatusId { get; set; }

        [Display(Name = "Сторона конфлікту")]
        public int? ConflictSideId { get; set; }

        [Display(Name = "Локація")]
        public int? LocationId { get; set; }

        [Display(Name = "Дата з")]
        [DataType(DataType.Date)]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "Дата по")]
        [DataType(DataType.Date)]
        public DateTime? DateTo { get; set; }

        [Display(Name = "Теги втрати")]
        public List<int>? TagIds { get; set; }
    }
}
