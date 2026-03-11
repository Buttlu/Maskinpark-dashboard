using Maskinpark.Models;

namespace Maskinpark.Infrastructure
{
    public interface IMachineRepository
    {
        bool AddMachine(Machine machine);
        Task<IReadOnlyCollection<Machine>> GetAllMachines();
        bool RemoveMachine(Guid machineId);
        bool RemoveMachine(Machine machine);
        bool StartMachine(Guid machineId);
        bool StartMachine(Machine machine);
        bool StopMachine(Guid machineId);
        bool StopMachine(Machine machine);
        bool UpdateMachineData(Guid machineId, string newData);
        bool UpdateMachineData(Machine machine, string newData);
    }
}