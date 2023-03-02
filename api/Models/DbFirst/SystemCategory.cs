using System;
using System.Collections.Generic;

namespace systeminventory_sample.Models.DbFirst;

public partial class SystemCategory
{
    public long Id { get; set; }

    public string? Name { get; set; }
}
