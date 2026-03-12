using MaskinPark.Contracts;
using MaskinPark.Infrastructure.Persistance;

namespace MaskinPark.Infrastructure.Repositories;

public class UnitOfWork(
    Lazy<IMachineRepository> machineRepository,
    ApplicationDbContext context
) : IUnitOfWork
{
    private readonly Lazy<IMachineRepository> _machineRepository = machineRepository;
    private readonly ApplicationDbContext _context = context;

    public IMachineRepository MachineRepository => _machineRepository.Value;

    public async Task CompleteAsync()
        => await _context.SaveChangesAsync();
}
