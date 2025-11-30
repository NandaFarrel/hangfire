using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_status")]
    public class TStatus
    {
        [Key]
        public int Id { get; set; }

        public string OpenProjectStatusId { get; set; }
        public string TrelloListId { get; set; }

        public string Name { get; set; } // e.g., "New", "In Progress", "Done"
    }
}