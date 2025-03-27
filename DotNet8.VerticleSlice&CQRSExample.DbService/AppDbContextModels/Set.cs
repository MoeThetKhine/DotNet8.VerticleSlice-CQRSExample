namespace DotNet8.VerticleSlice_CQRSExample.DbService.AppDbContextModels;

#region Set

public partial class Set
{
    public string Key { get; set; } = null!;

    public double Score { get; set; }

    public string Value { get; set; } = null!;

    public DateTime? ExpireAt { get; set; }
}

#endregion
