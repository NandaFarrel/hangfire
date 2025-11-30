using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
	[Table("ttfbgc1208888")]
	public class Master_ttfbgc1208888
	{
		//[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public long? ID_RECNUM { get; set; }
		public string T_ACNT { get; set; }
		public string T_DIM1 { get; set; }
		public string T_DIM2 { get; set; }
		public string T_DIM3 { get; set; }
		public string T_DIM4 { get; set; }
		public string T_DIM5 { get; set; }
		public string T_DIM6 { get; set; }
		public string T_DIM7 { get; set; }
		public string T_DIM8 { get; set; }
		public string T_DIM9 { get; set; }
		public string T_DM10 { get; set; }
		public string T_DM11 { get; set; }
		public string T_DM12 { get; set; }
		public string T_DIMS { get; set; }
		public string T_DSC1 { get; set; }
		public string T_DSC2 { get; set; }
		public decimal? T_CABG { get; set; }
		public decimal? T_LTDB { get; set; }
		public decimal? T_CHKA { get; set; }
		public decimal? T_EXBG { get; set; }
		public decimal? T_TAMT { get; set; }
		public string T_TCUR { get; set; }
		public decimal? T_TPRC { get; set; }
		public decimal? T_DCMP { get; set; }
		public string T_CWOC { get; set; }
		public string T_BMGR { get; set; }
		public decimal? T_LEVL { get; set; }
		public decimal? T_SORT { get; set; }
		public string T { get; set; }
		public decimal? T_REFCNTD { get; set; }
		public decimal? T_REFCNTU { get; set; }

		[Key]
		public DateTime? INSERT_DATE { get; set; }
		//public DateTime? UPDATE_DATE { get; set; }
		//public DateTime? CHECK_HFIRE_DATE { get; set; }

	}
}