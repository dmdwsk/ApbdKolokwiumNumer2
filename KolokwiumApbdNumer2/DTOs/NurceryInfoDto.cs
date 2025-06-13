namespace KolokwiumApbdNumer2.DTOs;

public class NurseryInfoDto
{
    public int NurseryId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime EstablishedDate { get; set; }
    public List<BatchDto> Batches { get; set; } = new();
}

public class BatchDto
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime ReadyDate { get; set; }
    public SpeciesDto Species { get; set; } = null!;
    public List<ResponsibleDto> Responsible { get; set; } = new();
}

public class SpeciesDto
{
    public string LatinName { get; set; } = null!;
    public int GrowthTimeInYears { get; set; }
}

public class ResponsibleDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Role { get; set; } = null!;
}