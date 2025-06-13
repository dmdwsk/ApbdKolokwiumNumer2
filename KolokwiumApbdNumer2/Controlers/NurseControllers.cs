
using KolokwiumApbdNumer2.Services;
using Microsoft.AspNetCore.Mvc;

namespace KolokwiumApbdNumer2.Controllers;

[ApiController]
[Route("api/nurseries")]
public class NurseControllers : ControllerBase
{
    private readonly IDbservice _service;

    public NurseControllers(IDbservice service)
    {
        _service = service;
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetNurseryWithBatches(int id)
    {
        var nursery = await _service.GetNurseryWithBatchesAsync(id);
        if (nursery is null)
            return NotFound($"Nursery with ID {id} not found.");

        return Ok(nursery);
    }
}