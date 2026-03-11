using Maskinpark.Models;

namespace Maskinpark.Infrastructure;

public class MachineRepository : IMachineRepository
{
    public bool AddMachine(Machine machine)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<Machine>> GetAllMachines()
    {
        throw new NotImplementedException();
    }

    public bool RemoveMachine(Machine machine)
    {
        throw new NotImplementedException();
    }

    public bool RemoveMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public bool StartMachine(Machine machine)
    {
        throw new NotImplementedException();
    }

    public bool StartMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public bool StopMachine(Machine machine)
    {
        throw new NotImplementedException();
    }

    public bool StopMachine(Guid machineId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateMachineData(Machine machine, string newData)
    {
        throw new NotImplementedException();
    }

    public bool UpdateMachineData(Guid machineId, string newData)
    {
        throw new NotImplementedException();
    }
}
