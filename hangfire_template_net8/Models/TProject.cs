using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_project")]
    public class TProject
    {
        [Key]
        public int Id { get; set; }

        public string OpenProjectIdentifier { get; set; } // e.g., "demo-project"
        public string TrelloBoardId { get; set; }

        public string Name { get; set; }
    }
}