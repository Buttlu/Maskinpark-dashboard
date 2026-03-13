namespace MaskinPark.Shared.Dtos;

public sealed record UpdateMachineDataDto(
    Guid MachineId,
    string NewData
);
