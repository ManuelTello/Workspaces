using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workspaces.Net.Web.Infrastructure.Models
{
    [Table("Activities")]
    public class Activity
    {
       [Key]
       [Column("id",TypeName="UUID")]
       public Guid Id { get; set; }

       [Column("title", TypeName = "VARCHAR(250)")]
       public string Title { get; set; } = string.Empty;

       [Column("content", TypeName = "VARCHAR(500)")]
       public string Content { get; set; } = string.Empty;
       
       [Column("is_completed", TypeName = "BOOLEAN")]
       public bool IsCompleted { get; set; }
       
       [Column("date_created",TypeName = "TIMESTAMP WITH TIME ZONE")]
       public DateTime DateCreated { get; set; }
       
       public Guid WorkspaceId { get; set; }

       public Workspace Workspace { get; set; } = null!;
    }
}