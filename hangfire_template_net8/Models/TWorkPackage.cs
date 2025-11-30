using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace hangfire_template.Models
{
    [Table("t_work_package")]
    [Index(nameof(OpenProjectWorkPackageId), IsUnique = true, Name = "IX_OPWorkPackageId")]
    [Index(nameof(TrelloCardId), IsUnique = true, Name = "IX_TrelloCardId")]
    public class TWorkPackage
    {
        [Key]
        [Column("id_work_package")]
        public int Id { get; set; }

        // --- ID dari Sistem Eksternal ---

        [StringLength(450)] // Menentukan panjang untuk kunci unik
        public string? OpenProjectWorkPackageId { get; set; }

        [StringLength(450)] // Menentukan panjang untuk kunci unik
        public string? TrelloCardId { get; set; }

        // --- Relasi ke Tabel Lain (Foreign Keys) ---
        public int? ProjectId { get; set; }
        public int? StatusId { get; set; }
        public int? AssigneeId { get; set; }

        // --- Properti Utama ---
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        // --- Relasi Navigasi (untuk Entity Framework) ---
        [ForeignKey("ProjectId")]
        public virtual TProject Project { get; set; }
        [ForeignKey("StatusId")]
        public virtual TStatus Status { get; set; }
        [ForeignKey("AssigneeId")]
        public virtual TUser Assignee { get; set; }

        public virtual ICollection<TComment> Comments { get; set; }
        public virtual ICollection<TChecklist> Checklists { get; set; }

        // --- Properti untuk Sinkronisasi ---
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastSyncedAt { get; set; }
        public bool NeedsOpSync { get; set; }
        public bool NeedsTrelloSync { get; set; }
    }
}