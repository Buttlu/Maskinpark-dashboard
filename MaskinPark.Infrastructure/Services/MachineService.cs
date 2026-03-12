using MaskinPark.Contracts;
using MaskinPark.Shared.Dtos;
using MaskinPark.Shared.Extensions;

namespace MaskinPark.Infrastructure.Services;

public class MachineService(
    IUnitOfWork unitOfWork
) : IMachineService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task AddMachine(MachineDto machineDto)
    {
        var machine = machineDto.ToEntity();
        await _unitOfWork.MachineRepository.AddMachine(machine);
        await _unitOfWork.CompleteAsync();
    }

    public Task<MachineDto> GetMachineByIdAsync(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<MachineDto>> GetMachinesAsync()
    {
        return [.. (await _unitOfWork.MachineRepository.GetMachinesAsync()).Select(m => m.ToDto())];
    }

    public Task RemoveMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public Task StartMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public Task StopMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMachineData(Guid machineId)
    {
        throw new NotImplementedException();
    }
}
