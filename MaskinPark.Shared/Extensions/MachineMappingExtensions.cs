using MaskinPark.Models.Entities;
using MaskinPark.Shared.Dtos;

namespace MaskinPark.Shared.Extensions;

public static class MachineMappingExtensions
{
    public static Machine ToEntity(this MachineDto machineDto)
        => new() {
            Id = machineDto.Id,
            Name = machineDto.Name,
            IsOnline = machineDto.IsOnline,
            LastData = machineDto.LastData,
            LastUpdated = machineDto.LastUpdated,
        };

    public static MachineDto ToDto(this Machine machine)
        => new(
            Id: machine.Id,
            Name: machine.Name,
            IsOnline: machine.IsOnline,
            LastData: machine.LastData,
            LastUpdated: machine.LastUpdated
        );
}
