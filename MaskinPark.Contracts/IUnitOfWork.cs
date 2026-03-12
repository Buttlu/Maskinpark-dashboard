namespace MaskinPark.Contracts;

public interface IUnitOfWork
{
    IMachineRepository MachineRepository { get; }

    Task CompleteAsync();
}
