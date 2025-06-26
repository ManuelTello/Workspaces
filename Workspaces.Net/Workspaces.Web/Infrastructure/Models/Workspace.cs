using System.ComponentModel.DataAnnotations.Schema;

namespace Workspaces.Net.Web.Infrastructure.Models
{
    [Table("Workspaces")]
    public class Workspace
    {
        public Guid Id { get; set; } 
    }
}