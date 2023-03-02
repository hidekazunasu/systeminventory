namespace inHouseSysmte.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("system")]

public class inHouseSysmteList
{
    [Column("Id")]
    public string Id { get; set; }

    [Column("SystemCategory")]
    public string? SystemCategory { get; set; }
    [Column("Name")]
    public string? Name { get; set; }

    [Column("Detail")]

    public string? Detail { get; set; }

    [Column("ProcessControl")]

    public int? ProcessControl { get; set; }

    public virtual ProcessControls ProcessControls { get; set; }

    public virtual SystemCategories GetSystemCategorie { get; set; }


}
