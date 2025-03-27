namespace DotNet8.VerticleSlice_CQRSExample.DbService.AppDbContextModels;

#region Server

public partial class Server
{
    public string Id { get; set; } = null!;

    public string? Data { get; set; }

    public DateTime LastHeartbeat { get; set; }
}

#endregion
