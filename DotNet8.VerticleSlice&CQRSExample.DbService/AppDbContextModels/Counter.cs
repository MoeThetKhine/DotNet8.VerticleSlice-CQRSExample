﻿namespace DotNet8.VerticleSlice_CQRSExample.DbService.AppDbContextModels;

public partial class Counter
{
    public string Key { get; set; } = null!;

    public int Value { get; set; }

    public DateTime? ExpireAt { get; set; }

    public long Id { get; set; }
}
