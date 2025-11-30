using System.ComponentModel.DataAnnotations; // <-- PASTIKAN USING INI ADA
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_checklist_item")]
    public class TChecklistItem
    {
        [Key] // <-- PERBAIKAN: Tambahkan anotasi [Key] di sini
        public int Id { get; set; }

        public int ChecklistId { get; set; } // Foreign Key

        public string OpenProjectItemId { get; set; }
        public string TrelloItemId { get; set; }

        public string Content { get; set; }
        public bool IsDone { get; set; }

        [ForeignKey("ChecklistId")]
        public virtual TChecklist Checklist { get; set; }
    }
}