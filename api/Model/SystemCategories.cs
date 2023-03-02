namespace inHouseSysmte.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("SystemCategories")]
public partial class SystemCategories
{
    public SystemCategories()
    {
        this.InHouseSysmteLists = new HashSet<inHouseSysmteList>();
    }


    public int? Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<inHouseSysmteList> InHouseSysmteLists { get; set; }


}
