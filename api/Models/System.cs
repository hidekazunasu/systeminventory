using System;
using System.Collections.Generic;

namespace systeminventory_sample.Models.DbFirst;

public partial class inHouseSystem
{
    public string? Id { get; set; }

    public long? SystemCategory { get; set; }

    public string? Name { get; set; }

    public string? Detail { get; set; }

    public long? ProcessControl { get; set; }
}
