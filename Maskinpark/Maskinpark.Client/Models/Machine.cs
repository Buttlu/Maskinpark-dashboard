namespace Maskinpark.Client.Models;

public class Machine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public bool IsOnline { get; set; } = false;
    public string StatusText => IsOnline ? "Online" : "Offline";
    public string LastData { get; set; } = string.Empty;
    public DateTime LastUpdated { get; set; } = DateTime.Now;
}
