using Maskinpark.Models;
using Maskinpark.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Maskinpark.Infrastructure;

public class MachineRepository(
    IDbContextFactory<ApplicationDbContext> contextFactory,
    ILogger<MachineRepository> logger
) : IMachineRepository
{
    private readonly ApplicationDbContext _context = contextFactory.CreateDbContext();
    private readonly ILogger<MachineRepository> _logger = logger;

    public async Task<bool> AddMachine(Machine machine)
    {
        try {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();
            return true;
        } catch (Exception ex) {
            _logger.LogError("Could not add machine to database: {ErrorMessage}", ex.Message);
            return false;
        }
    }

    public async Task<IReadOnlyCollection<Machine>> GetAllMachines()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveMachine(Machine machine)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> StartMachine(Machine machine)
    {
        throw new NotImplementedException();
    }

    public Task<bool> StartMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> StopMachine(Machine machine)
    {
        throw new NotImplementedException();
    }

    public Task<bool> StopMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMachineData(Machine machine, string newData)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMachineData(Guid machineId, string newData)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
