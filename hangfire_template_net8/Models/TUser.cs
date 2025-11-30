using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_user")]
    public class TUser
    {
        [Key]
        public int Id { get; set; }

        public string OpenProjectUserId { get; set; }
        public string TrelloMemberId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
    }
}