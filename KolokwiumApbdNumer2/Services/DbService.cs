using KolokwiumApbdNumer2.Data;
using KolokwiumApbdNumer2.DTOs;
using KolokwiumApbdNumer2.Services;
using Microsoft.EntityFrameworkCore;
public class DbService : IDbservice
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<NurseryInfoDto?> GetNurseryWithBatchesAsync(int nurseryId)
    {
        var nursery = await _context.Nurseries
            .Include(n => n.Batches)
            .ThenInclude(b => b.Species)
            .Include(n => n.Batches)
            .ThenInclude(b => b.ResponsibleEmployees)
            .ThenInclude(re => re.Employee)
            .FirstOrDefaultAsync(n => n.Id == nurseryId);
        

        if (nursery is null) return null;

        return new NurseryInfoDto()
        {
            NurseryId = nursery.Id,
            Name = nursery.Name,
            EstablishedDate = nursery.EstablishedDate,
            Batches = nursery.Batches.Select(b => new BatchDto
            {
                BatchId = b.Id,
                Quantity = b.Quantity,
                SownDate = b.ShownDate,
                ReadyDate = b.SownDate.AddYears(b.Species.GrowthTimeInYears),
                Species = new SpeciesDto
                {
                    LatinName = b.Species.LatinName,
                    GrowthTimeInYears = b.Species.GrowthTimeInYears
                },
                Responsible = b.ResponsibleEmployees.Select(re => new ResponsibleDto
                {
                    FirstName = re.Employee.FirstName,
                    LastName = re.Employee.LastName,
                    Role = re.Role
                }).ToList()
            }).ToList()
        };
    }
}

