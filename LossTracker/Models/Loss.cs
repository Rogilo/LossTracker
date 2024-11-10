using LossTracker.Models;
using System.ComponentModel.DataAnnotations;

public class Loss
{
    [Key]
    public int LossId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public Location Location { get; set; }
    public EquipmentType EquipmentType { get; set; }
    public LossStatus LossStatus { get; set; }
    public ConflictSide Side { get; set; }

    // Relationships
    public List<Photo> Photos { get; set; }
    public List<LossTag> Tags { get; set; } 
}
