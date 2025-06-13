using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumApbdNumer2.Models;
[Table("Tree_Species")]
public class TreeSpecies
{
    [Key]
    public int SpeciesId { get; set; }
    [MaxLength(100)] public string LatinName { get; set; } = null!;
    public int GrowthTimeInYears { get; set; }
    public ICollection<SeedlingBatch> SeedlingBatches { get; set; } = null!;
}