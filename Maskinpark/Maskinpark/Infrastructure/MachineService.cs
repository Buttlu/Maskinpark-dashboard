using Maskinpark.Client.Dtos;
using Maskinpark.Client.Interfaces;
using Maskinpark.Extensions;

namespace Maskinpark.Infrastructure;

public class MachineService(
    IMachineRepository machineRepository
) : IMachineService
{
    private readonly IMachineRepository _machineRepository = machineRepository;

    public async Task<bool> AddMachine(MachineDto machine)
        => await _machineRepository.AddMachine(machine.ToEntity());

    public async Task<IReadOnlyCollection<MachineDto>> GetAllMachines()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveMachine(MachineDto machine)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RemoveMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> StartMachine(MachineDto machine)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> StartMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> StopMachine(MachineDto machine)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> StopMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateMachineData(MachineDto machine, string newData)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateMachineData(Guid machineId, string newData)
    {
        throw new NotImplementedException();
    }
}
