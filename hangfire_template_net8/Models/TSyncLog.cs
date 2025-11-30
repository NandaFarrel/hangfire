using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_sync_log")]
    public class TSyncLog
    {
        [Key]
        [Column("id_sync_log")]
        public int IdSyncLog { get; set; }

        [Column("source")]
        public string Source { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("card_id")]
        public string CardId { get; set; }

        [Column("checklist_id")]
        public string ChecklistId { get; set; }

        [Column("checklist_item_id")]
        public string ChecklistItemId { get; set; }

        [Column("time_entry_id")]
        public string TimeEntryId { get; set; }

        [Column("work_package_id")]
        public string WorkPackageId { get; set; }

        [Column("activity_id")]
        public string ActivityId { get; set; }

        [Column("synced_at")]
        public DateTime? SyncedAt { get; set; }

        [Column("direction")]
        public string Direction { get; set; }

        [Column("sync_status")]
        public string SyncStatus { get; set; }

        [Column("error_message")]
        public string ErrorMessage { get; set; }
    }
}