using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
	[Table("ttdpur4008888")]
	public class Master_ttdpur4008888
	{
		//[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public long? ID_RECNUM { get; set; }
		public string T_ORNO { get; set; }
		public string T_OTBP { get; set; }
		public string T_OTAD { get; set; }
		public string T_OTCN { get; set; }
		public string T_SFBP { get; set; }
		public string T_SFAD { get; set; }
		public string T_SFCN { get; set; }
		public string T_IFBP { get; set; }
		public string T_IFAD { get; set; }
		public string T_IFCN { get; set; }
		public string T_PTBP { get; set; }
		public string T_PTAD { get; set; }
		public string T_PTCN { get; set; }
		public decimal? T_CORG { get; set; }
		public string T_COTP { get; set; }
		public string T_RAGR { get; set; }
		public string T_CPAY { get; set; }
		public DateTime? T_ODAT { get; set; }
		public decimal? T_ODIS { get; set; }
		public string T_CCUR { get; set; }
		public decimal? T_MCFR { get; set; }
		public decimal? T_RATP_1 { get; set; }
		public decimal? T_RATP_2 { get; set; }
		public decimal? T_RATP_3 { get; set; }
		public decimal? T_RATF_1 { get; set; }
		public decimal? T_RATF_2 { get; set; }
		public decimal? T_RATF_3 { get; set; }
		public DateTime? T_RATD { get; set; }
		public string T_RATT { get; set; }
		public decimal? T_RAUR { get; set; }
		public string T_SITE { get; set; }
		public string T_CWAR { get; set; }
		public string T_CADR { get; set; }
		public string T_CCON { get; set; }
		public string T_PLNR { get; set; }
		public string T_CCRS { get; set; }
		public string T_CFRW { get; set; }
		public string T_CPLP { get; set; }
		public string T_BPPR { get; set; }
		public string T_BPTX { get; set; }
		public string T_CDEC { get; set; }
		public string T_PTPA { get; set; }
		public DateTime? T_DDAT { get; set; }
		public DateTime? T_DDTC { get; set; }
		public string T_CBRN { get; set; }
		public string T_CREG { get; set; }
		public string T_REFA { get; set; }
		public string T_REFB { get; set; }
		public string T_PRNO { get; set; }
		public string T_CTRJ { get; set; }
		public string T_COFC { get; set; }
		public string T_FDPT { get; set; }
		public decimal? T_ODTY { get; set; }
		public string T_ODNO { get; set; }
		public string T_RETR { get; set; }
		public string T_SORN { get; set; }
		public string T_COSN { get; set; }
		public string T_AKCD { get; set; }
		public string T_CRCD { get; set; }
		public string T_CTCD { get; set; }
		public decimal? T_EGEN { get; set; }
		public decimal? T_SBIM { get; set; }
		public decimal? T_PAFT { get; set; }
		public string T_SBMT { get; set; }
		public string T_BPCL { get; set; }
		public decimal? T_OAMT { get; set; }
		public decimal? T_COMM { get; set; }
		public decimal? T_IEBP { get; set; }
		public decimal? T_IAFC { get; set; }
		public string T_LCCL { get; set; }
		public decimal? T_HDST { get; set; }
		public decimal? T_HISP { get; set; }
		public decimal? T_HISM { get; set; }
		public string T_ADIN { get; set; }
		public decimal? T_CHRQ { get; set; }
		public decimal? T_REVN { get; set; }
		public string T_OPOR { get; set; }
		public string T_CRBY { get; set; }
		public DateTime? T_CRDT { get; set; }
		public decimal? T_CROR { get; set; }
		public decimal? T_CRCL { get; set; }
		public decimal? T_CRIN { get; set; }
		public decimal? T_CRRQ { get; set; }
		public decimal? T_LCRQ { get; set; }
		public decimal? T_ETPC { get; set; }
		public string T_CCTY { get; set; }
		public decimal? T_CVYN { get; set; }
		public decimal? T_TXTA { get; set; }
		public decimal? T_TXTB { get; set; }
		public decimal? T_CRHT { get; set; }
		public string T_CDF_DESC { get; set; }
		public string T_CDF_LEVL { get; set; }
		public string T_CDF_RJMR { get; set; }
		public string T_CDF_RQNO { get; set; }
		public decimal? T_CDF_WRFL { get; set; }
		public decimal? T_REFCNTD { get; set; }
		public decimal? T_REFCNTU { get; set; }

		[Key]
		public DateTime? INSERT_DATE { get; set; }
		//public DateTime? UPDATE_DATE { get; set; }
		//public DateTime? CHECK_HFIRE_DATE { get; set; }

	}
}