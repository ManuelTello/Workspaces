using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workspaces.Net.Web.Infrastructure.Models
{
    [Table("activities")]
    public class Activity
    {
       [Key]
       [Column("id",TypeName="UUID")]
       public Guid Id { get; init; }

       [Column("title", TypeName = "VARCHAR(250)")]
       public string Title { get; init; } = string.Empty;

       [Column("content", TypeName = "TEXT")]
       public string Content { get; init; } = string.Empty;
       
       [Column("is_completed", TypeName = "BOOLEAN")]
       public bool IsCompleted { get; init; }
       
       [Column("date_created",TypeName = "TIMESTAMP WITH TIME ZONE")]
       public DateTime DateCreated { get; init; }
    }
}