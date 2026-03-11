using Maskinpark.Client.Dtos;
using Maskinpark.Models;

namespace Maskinpark.Extensions;

public static class MachineMapperExtensions
{
    public static MachineDto ToDto(this Machine machine)
        => new(
            Id: machine.Id,
            Name: machine.Name,
            IsOnline: machine.IsOnline,
            LastData: machine.LastData,
            LastUpdated: machine.LastUpdated
        );

    public static Machine ToEntity(this MachineDto machineDto)
        => new() {
            Id = machineDto.Id,
            Name = machineDto.Name,
            IsOnline = machineDto.IsOnline,
            LastData = machineDto.LastData,
            LastUpdated = machineDto.LastUpdated
        };
}
