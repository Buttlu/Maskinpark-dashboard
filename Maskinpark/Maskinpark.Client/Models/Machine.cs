namespace Maskinpark.Client.Models;

public class Machine
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsOnline { get; set; }
    public string StatusText => IsOnline ? "Online" : "Offline";
    public string LastData { get; set; } = string.Empty;
    public DateTime LastUpdated { get; set; }
}
