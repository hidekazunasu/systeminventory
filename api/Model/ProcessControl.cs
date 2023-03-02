namespace inHouseSysmte.Models;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ProcessControl")]
public partial class ProcessControls
{
    public ProcessControls()
    {
        this.InHouseSysmteLists = new HashSet<inHouseSysmteList>();
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<inHouseSysmteList> InHouseSysmteLists { get; set; }


}
