using Maskinpark.Models;

namespace Maskinpark.Infrastructure
{
    public interface IMachineRepository
    {
        Task<bool> AddMachine(Machine machine);
        Task<IReadOnlyCollection<Machine>> GetAllMachines();
        Task<bool> RemoveMachine(Guid machineId);
        Task<bool> RemoveMachine(Machine machine);
        Task<bool> StartMachine(Guid machineId);
        Task<bool> StartMachine(Machine machine);
        Task<bool> StopMachine(Guid machineId);
        Task<bool> StopMachine(Machine machine);
        Task<bool> UpdateMachineData(Guid machineId, string newData);
        Task<bool> UpdateMachineData(Machine machine, string newData);
    }
}