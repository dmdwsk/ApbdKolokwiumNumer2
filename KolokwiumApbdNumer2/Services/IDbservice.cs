using KolokwiumApbdNumer2.DTOs;

namespace KolokwiumApbdNumer2.Services;

public interface IDbservice
{
    Task<NurseryInfoDto> GetNurseryWithBatchesAsync(int nurceryId);
    
}