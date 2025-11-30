using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_time_entry")]
    public class TTimeEntry
    {
        [Key]
        public int Id { get; set; }

        public string OpenProjectTimeEntryId { get; set; }
        public string TrelloActionId { get; set; }

        public int WorkPackageId { get; set; }
        public int UserId { get; set; }

        public DateTime SpentOn { get; set; }
        public decimal Hours { get; set; }
        public string Comments { get; set; }

        [ForeignKey("WorkPackageId")]
        public virtual TWorkPackage WorkPackage { get; set; }
        [ForeignKey("UserId")]
        public virtual TUser User { get; set; }
    }
}