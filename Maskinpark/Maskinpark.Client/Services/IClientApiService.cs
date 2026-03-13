using MaskinPark.Shared.Dtos;

namespace Maskinpark.Client.Services
{
    public interface IClientApiService
    {
        Task AddMachineAsync(MachineDto machine, CancellationToken token = default);
        Task<IReadOnlyCollection<MachineDto>?> GetAllMachinesAsync(CancellationToken token = default);
    }
}