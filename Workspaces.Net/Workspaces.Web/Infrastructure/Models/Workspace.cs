using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workspaces.Net.Web.Infrastructure.Models
{
    [Table("Workspaces")]
    public class Workspace
    {
        [Key]
        [Column("id",TypeName = "UUID")]
        public Guid Id { get; set; }

        [Column("title", TypeName = "VARCHAR(250)")]
        public string Title { get; set; } = string.Empty;
        
        [Column("title", TypeName = "VARCHAR(500)")]       
        public string Description { get; set; } = string.Empty;
       
        [Column("date_created", TypeName = "TIMESTAMP WITH TIME ZONE")]
        public DateTime DateCreated { get; set; }
        
        ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}