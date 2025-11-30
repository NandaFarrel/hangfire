using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_comment")]
    public class TComment
    {
        [Key]
        public int Id { get; set; }

        public int WorkPackageId { get; set; } // Foreign Key ke t_work_package
        public int AuthorId { get; set; }      // Foreign Key ke t_user

        public string OpenProjectActivityId { get; set; }
        public string TrelloActionId { get; set; }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("WorkPackageId")]
        public virtual TWorkPackage WorkPackage { get; set; }
        [ForeignKey("AuthorId")]
        public virtual TUser Author { get; set; }
    }
}