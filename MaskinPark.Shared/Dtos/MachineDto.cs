namespace MaskinPark.Shared.Dtos;

public sealed record MachineDto(
    Guid Id,
    string Name,
    bool IsOnline,
    string LastData,
    DateTime LastUpdated
);
