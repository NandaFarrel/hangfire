using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
	[Table("ttdpur2008888")]
	public class Master_ttdpur2008888
	{
		//[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public long? ID_RECNUM { get; set; }
		public string T_RQNO { get; set; }
		public decimal? T_ORIG { get; set; }
		public string T_REMN { get; set; }
		public string T_RDEP { get; set; }
		public string T_COFC { get; set; }
		public DateTime? T_RDAT { get; set; }
		public string T_AEMN { get; set; }
		public string T_ADEP { get; set; }
		public DateTime? T_LTDT { get; set; }
		public decimal? T_RQST { get; set; }
		public decimal? T_CONV { get; set; }
		public string T_SITE { get; set; }
		public string T_CWAR { get; set; }
		public string T_DADR { get; set; }
		public string T_CPRJ { get; set; }
		public string T_CSPA { get; set; }
		public string T_CACT { get; set; }
		public string T_CSTL { get; set; }
		public string T_CCCO { get; set; }
		public DateTime? T_DLDT { get; set; }
		public string T_REFA { get; set; }
		public string T_REFB { get; set; }
		public string T_LOGN { get; set; }
		public string T_CCUR { get; set; }
		public string T_CCON { get; set; }
		public decimal? T_URGT { get; set; }
		public decimal? T_CNTY { get; set; }
		public decimal? T_SPAP { get; set; }
		public string T_RCOD { get; set; }
		public string T_ADIN { get; set; }
		public string T_CCTY { get; set; }
		public decimal? T_TXTA { get; set; }
		public string T_CDF_DESC { get; set; }
		public string T_CDF_LEVL { get; set; }
		public string T_CDF_RJMR { get; set; }
		public DateTime? T_CDF_TGLB { get; set; }
		public decimal? T_CDF_WRFL { get; set; }
		public decimal? T_REFCNTD { get; set; }
		public decimal? T_REFCNTU { get; set; }

		[Key]
		public DateTime? INSERT_DATE { get; set; }
		//public DateTime? UPDATE_DATE { get; set; }
		//public DateTime? CHECK_HFIRE_DATE { get; set; }

	}
}