using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KolokwiumApbdNumer2.Models;
[Table("Seedling_Batch")]
public class SeedlingBatch
{
    [Key]
    public int BatchId { get; set; }
    
    [ForeignKey(nameof(Nursery))]
    public int NurseryId { get; set; }
    [ForeignKey(nameof(TreeSpecies))]
    public int SpeciesId { get; set; }
    public int Quantity { get; set; }
    public DateTime ShownDate { get; set; }
    public DateTime ReadyDate { get; set; }
    
}