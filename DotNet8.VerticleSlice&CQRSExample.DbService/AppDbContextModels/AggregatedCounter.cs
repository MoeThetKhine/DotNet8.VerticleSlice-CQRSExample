namespace DotNet8.VerticleSlice_CQRSExample.DbService.AppDbContextModels;

#region AggregatedCounter

public partial class AggregatedCounter
{
    public string Key { get; set; } = null!;

    public long Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}

#endregion