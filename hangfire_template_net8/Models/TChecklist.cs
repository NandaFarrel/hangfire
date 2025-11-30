using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_checklist")]
    public class TChecklist
    {
        [Key]
        public int Id { get; set; }

        public int WorkPackageId { get; set; } // Foreign Key

        public string OpenProjectChecklistId { get; set; } // OpenProject tidak punya ID checklist, bisa diisi GUID
        public string TrelloChecklistId { get; set; }

        public string Name { get; set; }

        [ForeignKey("WorkPackageId")]
        public virtual TWorkPackage WorkPackage { get; set; }
        public virtual ICollection<TChecklistItem> Items { get; set; }
    }
}