using MaskinPark.Contracts;
using MaskinPark.Infrastructure.Persistance;
using MaskinPark.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaskinPark.Infrastructure.Repositories;

public class MachineRepository(ApplicationDbContext context) : IMachineRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task AddMachine(Machine machine)    
        => _context.Machines.Add(machine);
    

    public async Task<Machine?> GetMachineByIdAsync(Guid machineId)
        => _context.Machines.FirstOrDefault(m => m.Id == machineId);

    public async Task<IReadOnlyCollection<Machine>> GetMachinesAsync()
        => await _context.Machines
            .AsNoTracking()
            .ToListAsync();

    public async Task RemoveMachine(Guid machineId)
    {
        var machine = await GetMachineByIdAsync(machineId)
            ?? throw new ArgumentNullException(nameof(machineId));

        _context.Machines.Remove(machine);
    }

    public async Task StartMachine(Guid machineId)
    {
        var machine = await GetMachineByIdAsync(machineId)
            ?? throw new ArgumentNullException(nameof(machineId));

        machine.IsOnline = true;
    }

    public async Task StopMachine(Guid machineId)
    {
        var machine = await GetMachineByIdAsync(machineId)
            ?? throw new ArgumentNullException(nameof(machineId));

        machine.IsOnline = false;
    }

    public async Task UpdateMachineData(Guid machineId, string newData)
    {
        var machine = await GetMachineByIdAsync(machineId)
            ?? throw new ArgumentNullException(nameof(machineId));

        machine.LastData = newData;
    }
}
