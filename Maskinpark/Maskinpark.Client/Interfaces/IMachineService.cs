using Maskinpark.Client.Dtos;

namespace Maskinpark.Client.Interfaces;

public interface IMachineService
{
    Task<IReadOnlyCollection<MachineDto>> GetAllMachines();
    Task<bool> AddMachine(MachineDto machine);
    Task<bool> RemoveMachine(MachineDto machine);
    Task<bool> RemoveMachine(Guid machineId);
    Task<bool> StartMachine(MachineDto machine);
    Task<bool> StartMachine(Guid machineId);
    Task<bool> StopMachine(MachineDto machine);
    Task<bool> StopMachine(Guid machineId);
    Task<bool> UpdateMachineData(MachineDto machine, string newData);
    Task<bool> UpdateMachineData(Guid machineId, string newData);
}
