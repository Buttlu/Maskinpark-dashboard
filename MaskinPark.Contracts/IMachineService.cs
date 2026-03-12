using MaskinPark.Shared.Dtos;

namespace MaskinPark.Contracts;

public interface IMachineService
{
    Task<IReadOnlyCollection<MachineDto>> GetMachinesAsync();
    Task<MachineDto> GetMachineByIdAsync(Guid machineId);
    Task AddMachine(MachineDto machineDto);
    Task RemoveMachine(Guid machineId);
    Task StartMachine(Guid machineId);
    Task StopMachine(Guid machineId);
    Task UpdateMachineData(Guid machineId);
}
