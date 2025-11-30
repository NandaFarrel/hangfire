using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("tlkp_user_mapping")]
    public class TlkpUserMapping
    {
        [Key]
        public int mapping_id { get; set; }
        public string email { get; set; }
        public string trello_user_id { get; set; }
        public string openproject_user_id { get; set; }
    }
}