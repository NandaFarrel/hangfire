using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
	[Table("ttdpur4028888")]
	public class Master_ttdpur4028888
	{
		//[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public long? ID_RECNUM { get; set; }
		public string T_ORNO { get; set; }
		public decimal? T_PONO { get; set; }
		public decimal? T_SQNB { get; set; }
		public decimal? T_CORG { get; set; }
		public string T_OORN { get; set; }
		public decimal? T_OPON { get; set; }
		public decimal? T_OSQN { get; set; }
		public string T_SORN { get; set; }
		public decimal? T_SPON { get; set; }
		public decimal? T_SSEQ { get; set; }
		public decimal? T_SCSQ { get; set; }
		public string T_PDNO { get; set; }
		public decimal? T_OPNO { get; set; }
		public decimal? T_PPON { get; set; }
		public string T_LSTN { get; set; }
		public string T_SRVO { get; set; }
		public decimal? T_SRPO { get; set; }
		public decimal? T_SRSQ { get; set; }
		public string T_QONO { get; set; }
		public decimal? T_QPON { get; set; }
		public decimal? T_QALT { get; set; }
		public decimal? T_QSEQ { get; set; }
		public string T_FONO { get; set; }
		public decimal? T_FOPO { get; set; }
		public string T_RQNO { get; set; }
		public decimal? T_RQPO { get; set; }
		public decimal? T_ODTY { get; set; }
		public string T_ODNO { get; set; }
		public string T_RETO { get; set; }
		public decimal? T_RETP { get; set; }
		public decimal? T_RETS { get; set; }
		public decimal? T_RERS { get; set; }
		public decimal? T_RTYN { get; set; }
		public string T_MNWO { get; set; }
		public decimal? T_MNLP { get; set; }
		public decimal? T_MNSQ { get; set; }
		public decimal? T_INVC { get; set; }
		public decimal? T_REFCNTD { get; set; }
		public decimal? T_REFCNTU { get; set; }

		[Key]
		public DateTime? INSERT_DATE { get; set; }
		//public DateTime? UPDATE_DATE { get; set; }
		//public DateTime? CHECK_HFIRE_DATE { get; set; }

	}
}