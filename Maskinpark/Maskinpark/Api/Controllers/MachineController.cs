using MaskinPark.Contracts;
using MaskinPark.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Maskinpark.Api.Controllers;

[Route("api/machines")]
[ApiController]
public class MachineController(
    IMachineService machineService
) : ControllerBase
{
    private readonly IMachineService _machineService = machineService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var machines = await _machineService.GetMachinesAsync();
        return Ok(machines);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Add(MachineDto machineDto)
    {
        await _machineService.AddMachine(machineDto);
        return Created();
    }
}
