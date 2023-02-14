namespace inHouseSysmte.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("systems", Schema = "public")]

public class inHouseSysmteList
{
    [Column("id")]
    public string? Id { get; set; }

    [Column("SystemCategory")]
    public string? SystemCategory { get; set; }
    [Column("Name")]
    public string? Name { get; set; }

    [Column("Overview")]
    public string? Overview { get; set; }


}
