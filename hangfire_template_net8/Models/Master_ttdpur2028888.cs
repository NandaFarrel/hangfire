using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
	[Table("ttdpur2028888")]
	public class Master_ttdpur2028888
	{
		//[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public long? ID_RECNUM { get; set; }
		public string T_RQNO { get; set; }
		public decimal? T_PONO { get; set; }
		public string T_PDNO { get; set; }
		public string T_RSIT { get; set; }
		public string T_MNIT { get; set; }
		public string T_OPRO { get; set; }
		public string T_ROUC { get; set; }
		public string T_RORV { get; set; }
		public decimal? T_OPNO { get; set; }
		public decimal? T_OPSQ { get; set; }
		public decimal? T_PCLN { get; set; }
		public string T_SRVO { get; set; }
		public decimal? T_SRPO { get; set; }
		public string T_MNWO { get; set; }
		public decimal? T_MNLP { get; set; }
		public string T_PRNO { get; set; }
		public decimal? T_PPON { get; set; }
		public decimal? T_SQNB { get; set; }
		public string T_QONO { get; set; }
		public decimal? T_QPON { get; set; }
		public decimal? T_QSEQ { get; set; }
		public decimal? T_REFCNTD { get; set; }
		public decimal? T_REFCNTU { get; set; }

		[Key]
		public DateTime? INSERT_DATE { get; set; }
		//public DateTime? UPDATE_DATE { get; set; }
		//public DateTime? CHECK_HFIRE_DATE { get; set; }

	}
}