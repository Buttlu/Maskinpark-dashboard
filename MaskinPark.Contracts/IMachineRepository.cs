using MaskinPark.Models.Entities;

namespace MaskinPark.Contracts;

public interface IMachineRepository
{
    Task<IReadOnlyCollection<Machine>> GetMachinesAsync();
    Task<Machine?> GetMachineByIdAsync(Guid machineId);
    Task AddMachine(Machine machine);
    Task RemoveMachine(Guid machineId);
    Task StartMachine(Guid machineId);
    Task StopMachine(Guid machineId);
    Task UpdateMachineData(Guid machineId, string newData);
}
