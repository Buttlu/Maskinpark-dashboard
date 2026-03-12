using MaskinPark.Contracts;
using MaskinPark.Infrastructure.Persistance;
using MaskinPark.Models.Entities;

namespace MaskinPark.Infrastructure.Repositories;

public class MachineRepository(ApplicationDbContext context) : IMachineRepository
{
    private readonly ApplicationDbContext _context = context;
    private readonly ICollection<Machine> _machines = [];
    public async Task AddMachine(Machine machine)
    {
        //_context.Machines.Add(machine);
        _machines.Add(machine);
    }

    public async Task<Machine?> GetMachineByIdAsync(Guid machineId)
    {
        return _machines.FirstOrDefault(m => m.Id == machineId);
    }

    public async Task<IReadOnlyCollection<Machine>> GetMachinesAsync()
    {
        return [.. _machines];
    }

    public async Task RemoveMachine(Guid machineId)
    {
        var machine = await GetMachineByIdAsync(machineId)
            ?? throw new ArgumentNullException(nameof(machineId));

        _machines.Remove(machine);
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
