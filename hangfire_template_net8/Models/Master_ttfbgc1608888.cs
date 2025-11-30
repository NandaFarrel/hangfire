using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
	[Table("ttfbgc1608888")]
	public class Master_ttfbgc1608888
	{
		//[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public long? ID_RECNUM { get; set; }
		public decimal? T_YEAR { get; set; }
		public string T_BDGT { get; set; }
		public decimal? T_LEVL { get; set; }
		public string T_ACNT { get; set; }
		public string T_DIMS { get; set; }
		public decimal? T_PERD { get; set; }
		public decimal? T_BGAM { get; set; }
		public decimal? T_ALAM { get; set; }
		public decimal? T_RLAM { get; set; }
		public decimal? T_PAAM { get; set; }
		public decimal? T_REFCNTD { get; set; }
		public decimal? T_REFCNTU { get; set; }

		[Key]
		public DateTime? INSERT_DATE { get; set; }
		//public DateTime? UPDATE_DATE { get; set; }
		//public DateTime? CHECK_HFIRE_DATE { get; set; }

	}
}