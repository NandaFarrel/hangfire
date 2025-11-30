using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    public class TempListDataRejectPortal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64? prno { get; set; }
        public Int64? popo { get; set; }
        public string item { get; set; }
        public string mitm { get; set; }
        public DateTime? rdat { get; set; }
        public Decimal? qoor { get; set; }
        public string cwar { get; set; }
        public string cwoc { get; set; }
        public DateTime? crdt { get; set; }
    }

    public class TempListDataRejectINFOR
    {
        [Key]
        public long? prno { get; set; }
    }



    [Table("temp_reject_detinfor")]
    public class TempListDataRejectPortalDBSQL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64? id_recnum { get; set; }
        public Int64? prno { get; set; }
        public Int64? popo { get; set; }
        public string item { get; set; }
        public string mitm { get; set; }
        public DateTime? rdat { get; set; }
        public Decimal? qoor { get; set; }
        public string cwar { get; set; }
        public string cwoc { get; set; }
        public DateTime? insert_date { get; set; }
        public DateTime? crdt { get; set; }
    }
}