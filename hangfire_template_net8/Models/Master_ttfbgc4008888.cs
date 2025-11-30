using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
	[Table("ttfbgc4008888")]
	public class Master_ttfbgc4008888
	{
		//[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public long? ID_RECNUM { get; set; }
		public DateTime? T { get; set; }
		public decimal? T_SEQN { get; set; }
		public decimal? T_DCMP { get; set; }
		public decimal? T_DCIT { get; set; }
		public string T_DCMT { get; set; }
		public string T_DCLN { get; set; }
		public string T_DCRF { get; set; }
		public decimal? T_YEAR { get; set; }
		public string T_BDGT { get; set; }
		public decimal? T_LEVL { get; set; }
		public decimal? T_DSQN { get; set; }
		public decimal? T_DCST { get; set; }
		public decimal? T_TRTP { get; set; }
		public decimal? T_RDCP { get; set; }
		public decimal? T_RDIT { get; set; }
		public string T_RDCM { get; set; }
		public string T_RDLN { get; set; }
		public string T_RDRF { get; set; }
		public decimal? T_RDST { get; set; }
		public string T_ACNT { get; set; }
		public string T_DIMS { get; set; }
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
		public decimal? T_AMNT { get; set; }
		public string T_CCUR { get; set; }
		public decimal? T_DBCR { get; set; }
		public decimal? T_AMBC { get; set; }
		public decimal? T_RBAM { get; set; }
		public string T_BCUR { get; set; }
		public decimal? T_QNTY { get; set; }
		public decimal? T_RQTY { get; set; }
		public string T_UOMS { get; set; }
		public decimal? T_UPRC { get; set; }
		public DateTime? T_EFFD { get; set; }
		public decimal? T_TTAM { get; set; }
		public decimal? T_NRTA { get; set; }
		public string T_BPID { get; set; }
		public string T_ITEM { get; set; }
		public decimal? T_PERD { get; set; }
		public decimal? T_BABT { get; set; }
		public decimal? T_BAAT { get; set; }
		public string T_USER { get; set; }
		public string T_RTYP { get; set; }
		public DateTime? T_RTDT { get; set; }
		public decimal? T_RATE { get; set; }
		public decimal? T_BLTP { get; set; }
		public string T_BUYR { get; set; }
		public decimal? T_ENTP { get; set; }
		public string T_ENID { get; set; }
		public decimal? T_TETP { get; set; }
		public string T_TEID { get; set; }
		public string T_DACN { get; set; }
		public string T_DDM1 { get; set; }
		public string T_DDM2 { get; set; }
		public string T_DDM3 { get; set; }
		public string T_DDM4 { get; set; }
		public string T_DDM5 { get; set; }
		public string T_DDM6 { get; set; }
		public string T_DDM7 { get; set; }
		public string T_DDM8 { get; set; }
		public string T_DDM9 { get; set; }
		public string T_DD10 { get; set; }
		public string T_DD11 { get; set; }
		public string T_DD12 { get; set; }
		public decimal? T_TRST { get; set; }
		public string T_RSNC { get; set; }
		public decimal? T_EXCP { get; set; }
		public decimal? T_DAMT { get; set; }
		public decimal? T_DAIT { get; set; }
		public decimal? T_LAMN { get; set; }
		public decimal? T_LTTA { get; set; }
		public decimal? T_LNRT { get; set; }
		public decimal? T_DQTY { get; set; }
		public string T_DUOM { get; set; }
		public decimal? T_LQTY { get; set; }
		public DateTime? T_DCDT { get; set; }
		public string T_DRTP { get; set; }
		public string T_FTRT { get; set; }
		public decimal? T_DDCR { get; set; }
		public decimal? T_REIN { get; set; }
		public decimal? T_RERE { get; set; }
		public decimal? T_PCRE { get; set; }
		public decimal? T_FREC { get; set; }
		public decimal? T_FSHI { get; set; }
		public decimal? T_RECO { get; set; }
		public decimal? T_FRCO { get; set; }
		public decimal? T_INRE { get; set; }
		public decimal? T_CRNO { get; set; }
		public decimal? T_AUTR { get; set; }
		public decimal? T_CHNG { get; set; }
		public decimal? T_REFCNTD { get; set; }
		public decimal? T_REFCNTU { get; set; }

		[Key]
		public DateTime? INSERT_DATE { get; set; }
		//public DateTime? UPDATE_DATE { get; set; }
		//public DateTime? CHECK_HFIRE_DATE { get; set; }

	}
}