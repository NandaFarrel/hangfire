using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{

    [Table("t_sptstock")]
    public class Table_SPT_STOCK
    {
        [Key]
        public Int32? id { get; set; }
        public string spt_itemnum { get; set; }
        public string spt_whs { get; set; }
        public int? spt_type { get; set; }
        public DateTime? spt_createDate { get; set; }
        public string spt_createBy { get; set; }
        public int? spt_status { get; set; }
        public DateTime? spt_modifDate { get; set; }
        public string spt_modifBy { get; set; }
        public string spt_desc { get; set; }
        public int? spt_safety { get; set; }
        public int? spt_current { get; set; }
        public int? spt_reop { get; set; }
        public int? spt_max { get; set; }
        public int? spt_satuan { get; set; }
        public int? spt_loc { get; set; }
        public string spt_picture { get; set; }
        public string spt_picture2 { get; set; }
        public string spt_picture3 { get; set; }
        public string spt_partpjg { get; set; }
        public int? spt_slow { get; set; }
        public string spt_itemnew { get; set; }
        public string spt_remark { get; set; }
        public string spt_picture4 { get; set; }
        public string spt_picture5 { get; set; }


    }


    [Table("ttxmsl4298888")]
    public class ListSPCTPAD_ttxmsl4298888
    {
        [Key]
        [Column("ID")]
        public Int64? ID { get; set; }

        [JsonProperty(PropertyName = "T$ORNO")]
        [Column("T$ORNO")]
        public string ORNO { get; set; }

        [JsonProperty(PropertyName = "T$APBY")]
        [Column("T$APBY")]
        public string APBY { get; set; }

        [JsonProperty(PropertyName = "T$APDT")]
        [Column("T$APDT")]
        public DateTime? APDT { get; set; }

        [JsonProperty(PropertyName = "T$FLAG")]
        [Column("T$FLAG")]
        public Decimal? FLAG { get; set; }

    }

    [Table("ttxmsl4288888")]
    public class ListSPCTPAD_ttxmsl4288888
    {
        [Key]
        [Column("ID")]
        public Int64? ID { get; set; }

        [JsonProperty(PropertyName = "T$ORNO")]
        [Column("T$ORNO")]
        public string ORNO { get; set; }

        [JsonProperty(PropertyName = "T$APBY")]
        [Column("T$APBY")]
        public string APBY { get; set; }

        [JsonProperty(PropertyName = "T$APDT")]
        [Column("T$APDT")]
        public DateTime? APDT { get; set; }

        [JsonProperty(PropertyName = "T$FLAG")]
        [Column("T$FLAG")]
        public Decimal? FLAG { get; set; } 
        
        [JsonProperty(PropertyName = "T$STAT")]
        [Column("T$STAT")]
        public Decimal? STAT { get; set; }
        
        [JsonProperty(PropertyName = "T$REMK")]
        [Column("T$REMK")]
        public string REMK { get; set; }

    }

    [Table("twhwmd2158888")]
    public class ListSPCTPAD_twhwmd2158888
    {
        [Key]
        [Column("ID")]
        public Int64? ID { get; set; }

        [JsonProperty(PropertyName = "T$CWAR")]
        [Column("T$CWAR")]
        public string CWAR { get; set; }

        [JsonProperty(PropertyName = "T$ITEM")]
        [Column("T$ITEM")]
        public string ITEM { get; set; }

        [JsonProperty(PropertyName = "T$QHND")]
        [Column("T$QHND")]
        public Double? QHND { get; set; }
        
        [JsonProperty(PropertyName = "T$QCHD")]
        [Column("T$QCHD")]
        public Double? QCHD { get; set; }

         [JsonProperty(PropertyName = "T$QNHD")]
        [Column("T$QNHD")]
        public Double? QNHD { get; set; }

        [JsonProperty(PropertyName = "T$QBLK")]
        [Column("T$QBLK")]
        public Double? QBLK { get; set; }

        [JsonProperty(PropertyName = "T$QBPL")]
        [Column("T$QBPL")]
        public Double? QBPL { get; set; }

        [JsonProperty(PropertyName = "T$QORD")]
        [Column("T$QORD")]
        public Double? QORD { get; set; }

        [JsonProperty(PropertyName = "T$QOOR")]
        [Column("T$QOOR")]
        public Double? QOOR { get; set; }

        [JsonProperty(PropertyName = "T$QCOR")]
        [Column("T$QCOR")]
        public Double? QCOR { get; set; }

        [JsonProperty(PropertyName = "T$QNOR")]
        [Column("T$QNOR")]
        public Double? QNOR { get; set; }

        [JsonProperty(PropertyName = "T$QINT")]
        [Column("T$QINT")]
        public Double? QINT { get; set; }

        [JsonProperty(PropertyName = "T$QCIT")]
        [Column("T$QCIT")]
        public Double? QCIT { get; set; }

        [JsonProperty(PropertyName = "T$QNIT")]
        [Column("T$QNIT")]
        public Double? QNIT { get; set; }

        [JsonProperty(PropertyName = "T$QALL")]
        [Column("T$QALL")]
        public Double? QALL { get; set; }

        [JsonProperty(PropertyName = "T$QOAL")]
        [Column("T$QOAL")]
        public Double? QOAL { get; set; }

        [JsonProperty(PropertyName = "T$QCAL")]
        [Column("T$QCAL")]
        public Double? QCAL { get; set; }

        [JsonProperty(PropertyName = "T$QNAL")]
        [Column("T$QNAL")]
        public Double? QNAL { get; set; }

        [JsonProperty(PropertyName = "T$QNBL")]
        [Column("T$QNBL")]
        public Double? QNBL { get; set; }

        [JsonProperty(PropertyName = "T$QNBP")]
        [Column("T$QNBP")]
        public Double? QNBP { get; set; }

        [JsonProperty(PropertyName = "T$QCOM")]
        [Column("T$QCOM")]
        public Double? QCOM { get; set; }

        [JsonProperty(PropertyName = "T$QLAL")]
        [Column("T$QLAL")]
        public Double? QLAL { get; set; }

        [JsonProperty(PropertyName = "T$QCPR")]
        [Column("T$QCPR")]
        public Double? QCPR { get; set; }

        [JsonProperty(PropertyName = "T$QHRJ")]
        [Column("T$QHRJ")]
        public Double? QHRJ { get; set; }

        [JsonProperty(PropertyName = "T$QCRJ")]
        [Column("T$QCRJ")]
        public Double? QCRJ { get; set; }

        [JsonProperty(PropertyName = "T$QNRJ")]
        [Column("T$QNRJ")]
        public Double? QNRJ { get; set; }

        [JsonProperty(PropertyName = "T$LTDT")]
        [Column("T$LTDT")]
        public DateTime? LTDT { get; set; }

        [JsonProperty(PropertyName = "T$HSTD")]
        [Column("T$HSTD")]
        public DateTime? HSTD { get; set; }

        [JsonProperty(PropertyName = "T$LSID")]
        [Column("T$LSID")]
        public DateTime? LSID { get; set; }

        [JsonProperty(PropertyName = "T$QCIS")]
        [Column("T$QCIS")]
        public Double? QCIS { get; set; }

        [JsonProperty(PropertyName = "T$QHIB")]
        [Column("T$QHIB")]
        public Double? QHIB { get; set; }

    }


    [Table("twhinh5218888")]
    public class ListSPCTPAD_twhinh5218888
    {
        [Key]
        [Column("ID")]
        public Int64? ID { get; set; }

        [JsonProperty(PropertyName = "T$ORNO")]
        [Column("T$ORNO")]
        public string ORNO { get; set; }

        [JsonProperty(PropertyName = "T$PONO")]
        [Column("T$PONO")]
        public int PONO { get; set; }

        [JsonProperty(PropertyName = "T$CWAR")]
        [Column("T$CWAR")]
        public string CWAR { get; set; }

        [JsonProperty(PropertyName = "T$LOCA")]
        [Column("T$LOCA")]
        public string LOCA { get; set; }

        [JsonProperty(PropertyName = "T$ITEM")]
        [Column("T$ITEM")]
        public string ITEM { get; set; }

        [JsonProperty(PropertyName = "T$CLOT")]
        [Column("T$CLOT")]
        public string CLOT { get; set; }

        [JsonProperty(PropertyName = "T$IDAT")]
        [Column("T$IDAT")]
        public DateTime? IDAT { get; set; }

        [JsonProperty(PropertyName = "T$STUN")]
        [Column("T$STUN")]
        public string STUN { get; set; }

        [JsonProperty(PropertyName = "T$PKDF")]
        [Column("T$PKDF")]
        public string PKDF { get; set; }

        [JsonProperty(PropertyName = "T$HUID")]
        [Column("T$HUID")]
        public string HUID { get; set; }

        [JsonProperty(PropertyName = "T$HUPR")]
        [Column("T$HUPR")]
        public Decimal? HUPR { get; set; }

        [JsonProperty(PropertyName = "T$QSTP")]
        [Column("T$QSTP")]
        public Decimal? QSTP { get; set; }

        [JsonProperty(PropertyName = "T$QSTR")]
        [Column("T$QSTR")]
        public Decimal? QSTR { get; set; }

        [JsonProperty(PropertyName = "T$QADJ")]
        [Column("T$QADJ")]
        public Decimal? QADJ { get; set; }

        [JsonProperty(PropertyName = "T$QADR")]
        [Column("T$QADR")]
        public Decimal? QADR { get; set; }

        [JsonProperty(PropertyName = "T$QVRC")]
        [Column("T$QVRC")]
        public Decimal? QVRC { get; set; }

        [JsonProperty(PropertyName = "T$QVRR")]
        [Column("T$QVRR")]
        public Decimal? QVRR { get; set; }

        [JsonProperty(PropertyName = "T$RJIN")]
        [Column("T$RJIN")]
        public Decimal? RJIN { get; set; }

        [JsonProperty(PropertyName = "T$ADAT")]
        [Column("T$ADAT")]
        public DateTime? ADAT { get; set; }

        [JsonProperty(PropertyName = "T$ADRN")]
        [Column("T$ADRN")]
        public string ADRN { get; set; }

        [JsonProperty(PropertyName = "T$UAPR")]
        [Column("T$UAPR")]
        public Decimal? UAPR { get; set; }

        [JsonProperty(PropertyName = "T$ADPR")]
        [Column("T$ADPR")]
        public Int64? ADPR { get; set; }

        [JsonProperty(PropertyName = "T$PRIC")]
        [Column("T$PRIC")]
        public Decimal? PRIC { get; set; }

        [JsonProperty(PropertyName = "T$AMNT")]
        [Column("T$AMNT")]
        public Decimal? AMNT { get; set; }

        [JsonProperty(PropertyName = "T$OWNS")]
        [Column("T$OWNS")]
        public Decimal? OWNS { get; set; }

        [JsonProperty(PropertyName = "T$OWNR")]
        [Column("T$OWNR")]
        public string OWNR { get; set; }

        [JsonProperty(PropertyName = "T$ISTR")]
        [Column("T$ISTR")]
        public Decimal? ISTR { get; set; }

        [JsonProperty(PropertyName = "T$IFBP")]
        [Column("T$IFBP")]
        public string IFBP { get; set; }

        [JsonProperty(PropertyName = "T$IOWN")]
        [Column("T$IOWN")]
        public Decimal? IOWN { get; set; }

        [JsonProperty(PropertyName = "T$DPBY")]
        [Column("T$DPBY")]
        public Decimal? DPBY { get; set; }

        [JsonProperty(PropertyName = "T$PRCD")]
        [Column("T$PRCD")]
        public Decimal? PRCD { get; set; }

        [JsonProperty(PropertyName = "T$SPCN")]
        [Column("T$SPCN")]
        public string SPCN { get; set; }

        [JsonProperty(PropertyName = "T$TXTA")]
        [Column("T$TXTA")]
        public string TXTA { get; set; }

        [JsonProperty(PropertyName = "T$REFCNTD")]
        [Column("T$REFCNTD")]
        public Decimal? REFCNTD { get; set; }

        [JsonProperty(PropertyName = "T$REFCNTU")]
        [Column("T$REFCNTU")]
        public Decimal? REFCNTU { get; set; }

    }


    [Table("twhinr1108888")]
    public class ListSPCTPAD_twhinr1108888
    {
        [Key]
        [Column("ID")]
        public Int64? ID { get; set; }

        [JsonProperty(PropertyName = "T$ITEM")]
        [Column("T$ITEM")]
        public string ITEM { get; set; }

        [JsonProperty(PropertyName = "T$CWAR")]
        [Column("T$CWAR")]
        public string CWAR { get; set; }

        [JsonProperty(PropertyName = "T$TRDT")]
        [Column("T$TRDT")]
        public DateTime? TRDT { get; set; }

        [JsonProperty(PropertyName = "T$SEQN")]
        [Column("T$SEQN")]
        public Int64? SEQN { get; set; }

        [JsonProperty(PropertyName = "T$SITE")]
        [Column("T$SITE")]
        public string SITE { get; set; }

        [JsonProperty(PropertyName = "T$EFFN")]
        [Column("T$EFFN")]
        public Int64 EFFN { get; set; }

        [JsonProperty(PropertyName = "T$SERL")]
        [Column("T$SERL")]
        public string SERL { get; set; }

        [JsonProperty(PropertyName = "T$CLOT")]
        [Column("T$CLOT")]
        public string CLOT { get; set; }

        [JsonProperty(PropertyName = "T$QSTK")]
        [Column("T$QSTK")]
        public Double? QSTK { get; set; }

        [JsonProperty(PropertyName = "T$OCMP")]
        [Column("T$OCMP")]
        public int? OCMP { get; set; }

        [JsonProperty(PropertyName = "T$KOOR")]
        [Column("T$KOOR")]
        public Decimal? KOOR { get; set; }

        [JsonProperty(PropertyName = "T$KOST")]
        [Column("T$KOST")]
        public Decimal? KOST { get; set; }

        [JsonProperty(PropertyName = "T$ITID")]
        [Column("T$ITID")]
        public string ITID { get; set; }

        [JsonProperty(PropertyName = "T$ITSE")]
        [Column("T$ITSE")]
        public Int64? ITSE { get; set; }

        [JsonProperty(PropertyName = "T$ORNO")]
        [Column("T$ORNO")]
        public string ORNO { get; set; }

        [JsonProperty(PropertyName = "T$PONO")]
        [Column("T$PONO")]
        public int? PONO { get; set; }

        [JsonProperty(PropertyName = "T$SRNB")]
        [Column("T$SRNB")]
        public int? SRNB { get; set; }

        [JsonProperty(PropertyName = "T$BOML")]
        [Column("T$BOML")]
        public int? BOML { get; set; }

        [JsonProperty(PropertyName = "T$DLIN")]
        [Column("T$DLIN")]
        public int? DLIN { get; set; }

        [JsonProperty(PropertyName = "T$RCNO")]
        [Column("T$RCNO")]
        public string RCNO { get; set; }

        [JsonProperty(PropertyName = "T$RCLN")]
        [Column("T$RCLN")]
        public int? RCLN { get; set; }

        [JsonProperty(PropertyName = "T$PYPS")]
        [Column("T$PYPS")]
        public Int64? PYPS { get; set; }

        [JsonProperty(PropertyName = "T$SHPM")]
        [Column("T$SHPM")]
        public string SHPM { get; set; }

        [JsonProperty(PropertyName = "T$SHPO")]
        [Column("T$SHPO")]
        public int? SHPO { get; set; }

        [JsonProperty(PropertyName = "T$BPID")]
        [Column("T$BPID")]
        public string BPID { get; set; }

        [JsonProperty(PropertyName = "T$CPRJ")]
        [Column("T$CPRJ")]
        public string CPRJ { get; set; }

        [JsonProperty(PropertyName = "T$CSPA")]
        [Column("T$CSPA")]
        public string CSPA { get; set; }

        [JsonProperty(PropertyName = "T$CACT")]
        [Column("T$CACT")]
        public string CACT { get; set; }

        [JsonProperty(PropertyName = "T$CSTL")]
        [Column("T$CSTL")]
        public string CSTL { get; set; }

        [JsonProperty(PropertyName = "T$CCCO")]
        [Column("T$CCCO")]
        public string CCCO { get; set; }

        [JsonProperty(PropertyName = "T$PRJP")]
        [Column("T$PRJP")]
        public Decimal? PRJP { get; set; }

        [JsonProperty(PropertyName = "T$PRNT")]
        [Column("T$PRNT")]
        public Decimal PRNT { get; set; }

        [JsonProperty(PropertyName = "T$CHAN")]
        [Column("T$CHAN")]
        public string CHAN { get; set; }

        [JsonProperty(PropertyName = "T$QHND")]
        [Column("T$QHND")]
        public Double? QHND { get; set; }

        [JsonProperty(PropertyName = "T$LOGN")]
        [Column("T$LOGN")]
        public string LOGN { get; set; }

        [JsonProperty(PropertyName = "T$CONS")]
        [Column("T$CONS")]
        public Decimal? CONS { get; set; }

        [JsonProperty(PropertyName = "T$OWNS")]
        [Column("T$OWNS")]
        public Decimal? OWNS { get; set; }

        [JsonProperty(PropertyName = "T$OWNR")]
        [Column("T$OWNR")]
        public string OWNR { get; set; }

        [JsonProperty(PropertyName = "T$BFBP")]
        [Column("T$BFBP")]
        public string BFBP { get; set; }

        [JsonProperty(PropertyName = "T$PHTR")]
        [Column("T$PHTR")]
        public Decimal? PHTR { get; set; }

        [JsonProperty(PropertyName = "T$COSV")]
        [Column("T$COSV")]
        public Decimal? COSV { get; set; }

        [JsonProperty(PropertyName = "T$REJE")]
        [Column("T$REJE")]
        public Decimal? REJE { get; set; }

        [JsonProperty(PropertyName = "T$RECO")]
        [Column("T$RECO")]
        public Decimal? RECO { get; set; }

        [JsonProperty(PropertyName = "T$VALM")]
        [Column("T$VALM")]
        public Decimal? VALM { get; set; }

        [JsonProperty(PropertyName = "T$VWVG")]
        [Column("T$VWVG")]
        public Decimal? VWVG { get; set; }

        [JsonProperty(PropertyName = "T$WVGR")]
        [Column("T$WVGR")]
        public string WVGR { get; set; }

        [JsonProperty(PropertyName = "T$LGDT")]
        [Column("T$LGDT")]
        public DateTime? LGDT { get; set; }

        [JsonProperty(PropertyName = "T$ISEQ")]
        [Column("T$ISEQ")]
        public int? ISEQ { get; set; }

        [JsonProperty(PropertyName = "T$TTYP")]
        [Column("T$TTYP")]
        public string TTYP { get; set; }

        [JsonProperty(PropertyName = "T$CINV")]
        [Column("T$CINV")]
        public Int64? CINV { get; set; }

        [JsonProperty(PropertyName = "T$INVD")]
        [Column("T$INVD")]
        public DateTime? INVD { get; set; }

        [JsonProperty(PropertyName = "T$ITRD")]
        [Column("T$ITRD")]
        public DateTime? ITRD { get; set; }

        [JsonProperty(PropertyName = "T$ILGD")]
        [Column("T$ILGD")]
        public DateTime? ILGD { get; set; }

        [JsonProperty(PropertyName = "T$SPCN")]
        [Column("T$SPCN")]
        public string SPCN { get; set; }

        [JsonProperty(PropertyName = "T$REFCNTD")]
        [Column("T$REFCNTD")]
        public Decimal? REFCNTD { get; set; }

        [JsonProperty(PropertyName = "T$REFCNTU")]
        [Column("T$REFCNTU")]
        public Decimal? REFCNTU { get; set; }

    }

    [Table("ttdpur2018888")]
    public class ListSPCTPAD_ttdpur2018888
    {
        [Key]
        [Column("ID")]
        public Int64? ID { get; set; }

        [JsonProperty("T$RQNO")]
        [Column("T$RQNO")]
        public string TTRQNO { get; set; }

        [JsonProperty("T$PONO")]
        [Column("T$PONO")]
        public int? TPONO { get; set; }

        [JsonProperty("T$ITEM")]
        [Column("T$ITEM")]
        public string TITEM { get; set; }

        [JsonProperty("T$NIDS")]
        [Column("T$NIDS")]
        public string TNIDS { get; set; }

        [JsonProperty("T$EFFN")]
        [Column("T$EFFN")]
        public Int64? TEFFN { get; set; }

        [JsonProperty("T$CRRF")]
        [Column("T$CRRF")]
        public decimal? TCRRF { get; set; }

        [JsonProperty("T$CITT")]
        [Column("T$CITT")]
        public string TCITT { get; set; }

        [JsonProperty("T$CRIT")]
        [Column("T$CRIT")]
        public string TCRIT { get; set; }

        [JsonProperty("T$MPNR")]
        [Column("T$MPNR")]
        public string TMPNR { get; set; }

        [JsonProperty("T$CMNF")]
        [Column("T$CMNF")]
        public string TCMNF { get; set; }

        [JsonProperty("T$MITM")]
        [Column("T$MITM")]
        public string TMITM { get; set; }

        [JsonProperty("T$QOOR")]
        [Column("T$QOOR")]
        public decimal? TQOOR { get; set; }

        [JsonProperty("T$CUQP")]
        [Column("T$CUQP")]
        public string TCUQP { get; set; }

        [JsonProperty("T$CVQP")]
        [Column("T$CVQP")]
        public decimal? TCVQP { get; set; }

        [JsonProperty("T$LENG")]
        [Column("T$LENG")]
        public decimal? TLENG { get; set; }

        [JsonProperty("T$WIDT")]
        [Column("T$WIDT")]
        public decimal? TWIDT { get; set; }

        [JsonProperty("T$THIC")]
        [Column("T$THIC")]
        public decimal? TTHIC { get; set; }

        [JsonProperty("T$OTBP")]
        [Column("T$OTBP")]
        public string TOTBP { get; set; }

        [JsonProperty("T$NSDS")]
        [Column("T$NSDS")]
        public string TNSDS { get; set; }

        [JsonProperty("T$CCON")]
        [Column("T$CCON")]
        public string TCCON { get; set; }

        [JsonProperty("T$DLDT")]
        [Column("T$DLDT")]
        public DateTime? TDLDT { get; set; }

        [JsonProperty("T$PRIC")]
        [Column("T$PRIC")]
        public decimal? TPRIC { get; set; }

        [JsonProperty("T$CUPP")]
        [Column("T$CUPP")]
        public string TCUPP { get; set; }

        [JsonProperty("T$CVPP")]
        [Column("T$CVPP")]
        public decimal? TCVPP { get; set; }

        [JsonProperty("T$OAMT")]
        [Column("T$OAMT")]
        public decimal? TOAMT { get; set; }

        [JsonProperty("T$SITE")]
        [Column("T$SITE")]
        public string TSITE { get; set; }

        [JsonProperty("T$CWAR")]
        [Column("T$CWAR")]
        public string TCWAR { get; set; }

        [JsonProperty("T$CADR")]
        [Column("T$CADR")]
        public string TCADR { get; set; }

        [JsonProperty("T$CPRJ")]
        [Column("T$CPRJ")]
        public string TCPRJ { get; set; }

        [JsonProperty("T$CSPA")]
        [Column("T$CSPA")]
        public string TCSPA { get; set; }

        [JsonProperty("T$CACT")]
        [Column("T$CACT")]
        public string TCACT { get; set; }

        [JsonProperty("T$CSTL")]
        [Column("T$CSTL")]
        public string TCSTL { get; set; }

        [JsonProperty("T$CCCO")]
        [Column("T$CCCO")]
        public string TCCCO { get; set; }

        [JsonProperty("T$GLCO")]
        [Column("T$GLCO")]
        public string TGLCO { get; set; }

        [JsonProperty("T$REJC")]
        [Column("T$REJC")]
        public decimal? TREJC { get; set; }

        [JsonProperty("T$RCOD")]
        [Column("T$RCOD")]
        public string TRCOD { get; set; }

        [JsonProperty("T$URGT")]
        [Column("T$URGT")]
        public decimal? TURGT { get; set; }

        [JsonProperty("T$CNTY")]
        [Column("T$CNTY")]
        public decimal? TCNTY { get; set; }

        [JsonProperty("T$BGXC")]
        [Column("T$BGXC")]
        public decimal? TBGXC { get; set; }

        [JsonProperty("T$PEGD")]
        [Column("T$PEGD")]
        public decimal? TPEGD { get; set; }

        [JsonProperty("T$ADIN")]
        [Column("T$ADIN")]
        public string TADIN { get; set; }

        [JsonProperty("T$CPLA")]
        [Column("T$CPLA")]
        public string TCPLA { get; set; }

        [JsonProperty("T$TXTA")]
        [Column("T$TXTA")]
        public string TTXTA { get; set; }

        [JsonProperty("T$REFCNTD")]
        [Column("T$REFCNTD")]
        public decimal? TREFCNTD { get; set; }

        [JsonProperty("T$REFCNTU")]
        [Column("T$REFCNTU")]
        public decimal? TREFCNTU { get; set; }


    }


    [Table("ttcibd0018888")]
    public class ListSPCTPAD_ttcibd0018888
    {
        [Key]
        [Column("ID")]
        public Int64? ID { get; set; }

        [JsonProperty("T$ITEM")]
        [Column("T$ITEM")]
        public string TITEM { get; set; }

        [JsonProperty("T$DSCA")]
        [Column("T$DSCA")]
        public string TDSCA { get; set; }

        [JsonProperty("T$SEAK")]
        [Column("T$SEAK")]
        public string TSEAK { get; set; }

        [JsonProperty("T$SEAB")]
        [Column("T$SEAB")]
        public string TSEAB { get; set; }

        [JsonProperty("T$EXIN")]
        [Column("T$EXIN")]
        public string TEXIN { get; set; }

        [JsonProperty("T$IMAG")]
        [Column("T$IMAG")]
        public string TIMAG { get; set; }

        [JsonProperty("T$CRDT")]
        [Column("T$CRDT")]
        public DateTime? TCRDT { get; set; }

        [JsonProperty("T$LMDT")]
        [Column("T$LMDT")]
        public DateTime? TLMDT { get; set; }

        [JsonProperty("T$COOD")]
        [Column("T$COOD")]
        public string TCOOD { get; set; }

        [JsonProperty("T$KITM")]
        [Column("T$KITM")]
        public decimal? TKITM { get; set; }

        [JsonProperty("T$CITG")]
        [Column("T$CITG")]
        public string TCITG { get; set; }

        [JsonProperty("T$ITMT")]
        [Column("T$ITMT")]
        public decimal? TITMT { get; set; }

        [JsonProperty("T$OSYS")]
        [Column("T$OSYS")]
        public decimal? TOSYS { get; set; }

        [JsonProperty("T$CUNI")]
        [Column("T$CUNI")]
        public string TCUNI { get; set; }

        [JsonProperty("T$USET")]
        [Column("T$USET")]
        public string TUSET { get; set; }

        [JsonProperty("T$LTCT")]
        [Column("T$LTCT")]
        public decimal? TLTCT { get; set; }

        [JsonProperty("T$SERI")]
        [Column("T$SERI")]
        public decimal? TSERI { get; set; }

        [JsonProperty("T$CNFG")]
        [Column("T$CNFG")]
        public decimal? TCNFG { get; set; }

        [JsonProperty("T$REPL")]
        [Column("T$REPL")]
        public decimal? TREPL { get; set; }

        [JsonProperty("T$CPRJ")]
        [Column("T$CPRJ")]
        public string TCPRJ { get; set; }

        [JsonProperty("T$CPVA")]
        [Column("T$CPVA")]
        public Int64? TCPVA { get; set; }

        [JsonProperty("T$DFIT")]
        [Column("T$DFIT")]
        public string TDFIT { get; set; }

        [JsonProperty("T$STOI")]
        [Column("T$STOI")]
        public int? TSTOI { get; set; }

        [JsonProperty("T$OPTS")]
        [Column("T$OPTS")]
        public int? TOPTS { get; set; }

        [JsonProperty("T$CUST")]
        [Column("T$CUST")]
        public int? TCUST { get; set; }

        [JsonProperty("T$OPOL")]
        [Column("T$OPOL")]
        public int? TOPOL { get; set; }

        [JsonProperty("T$WPCS")]
        [Column("T$WPCS")]
        public int? TWPCS { get; set; }

        [JsonProperty("T$CCFG")]
        [Column("T$CCFG")]
        public string TCCFG { get; set; }

        [JsonProperty("T$UNEF")]
        [Column("T$UNEF")]
        public int? TUNEF { get; set; }

        [JsonProperty("T$ICHG")]
        [Column("T$ICHG")]
        public int? TICHG { get; set; }

        [JsonProperty("T$EITM")]
        [Column("T$EITM")]
        public int? TEITM { get; set; }

        [JsonProperty("T$UEFS")]
        [Column("T$UEFS")]
        public int? TUEFS { get; set; }

        [JsonProperty("T$UMER")]
        [Column("T$UMER")]
        public int? TUMER { get; set; }

        [JsonProperty("T$CHMA")]
        [Column("T$CHMA")]
        public int? TCHMA { get; set; }

        [JsonProperty("T$EFCO")]
        [Column("T$EFCO")]
        public string TEFCO { get; set; }

        [JsonProperty("T$INDT")]
        [Column("T$INDT")]
        public DateTime? TINDT { get; set; }

        [JsonProperty("T$EDCO")]
        [Column("T$EDCO")]
        public int? TEDCO { get; set; }

        [JsonProperty("T$MCOA")]
        [Column("T$MCOA")]
        public int? TMCOA { get; set; }

        [JsonProperty("T$SAYN")]
        [Column("T$SAYN")]
        public int? TSAYN { get; set; }

        [JsonProperty("T$CONT")]
        [Column("T$CONT")]
        public int? TCONT { get; set; }

        [JsonProperty("T$CNTR")]
        [Column("T$CNTR")]
        public string TCNTR { get; set; }

        [JsonProperty("T$CPCP")]
        [Column("T$CPCP")]
        public string TCPCP { get; set; }

        [JsonProperty("T$COEU")]
        [Column("T$COEU")]
        public int? TCOEU { get; set; }

        [JsonProperty("T$PPEG")]
        [Column("T$PPEG")]
        public int? TPPEG { get; set; }

        [JsonProperty("T$IPPG")]
        [Column("T$IPPG")]
        public int? TIPPG { get; set; }

        [JsonProperty("T$PPSS")]
        [Column("T$PPSS")]
        public int? TPPSS { get; set; }

        [JsonProperty("T$ELCM")]
        [Column("T$ELCM")]
        public int? TELCM { get; set; }

        [JsonProperty("T$ELRQ")]
        [Column("T$ELRQ")]
        public int? TELRQ { get; set; }

        [JsonProperty("T$DPEG")]
        [Column("T$DPEG")]
        public int? TDPEG { get; set; }

        [JsonProperty("T$DPTP")]
        [Column("T$DPTP")]
        public int? TDPTP { get; set; }

        [JsonProperty("T$DPUU")]
        [Column("T$DPUU")]
        public int? TDPUU { get; set; }

        [JsonProperty("T$SGTC")]
        [Column("T$SGTC")]
        public int? TSGTC { get; set; }

        [JsonProperty("T$SRCE")]
        [Column("T$SRCE")]
        public int? TSRCE { get; set; }

        [JsonProperty("T$EFPR")]
        [Column("T$EFPR")]
        public int? TEFPR { get; set; }

        [JsonProperty("T$DSCB")]
        [Column("T$DSCB")]
        public string TDSCB { get; set; }

        [JsonProperty("T$DSCC")]
        [Column("T$DSCC")]
        public string TDSCC { get; set; }

        [JsonProperty("T$DSCD")]
        [Column("T$DSCD")]
        public string TDSCD { get; set; }

        [JsonProperty("T$WGHT")]
        [Column("T$WGHT")]
        public decimal? TWGHT { get; set; }

        [JsonProperty("T$CWUN")]
        [Column("T$CWUN")]
        public string TCWUN { get; set; }

        [JsonProperty("T$CTYP")]
        [Column("T$CTYP")]
        public string TCTYP { get; set; }

        [JsonProperty("T$CPCL")]
        [Column("T$CPCL")]
        public string TCPCL { get; set; }

        [JsonProperty("T$CPLN")]
        [Column("T$CPLN")]
        public string TCPLN { get; set; }

        [JsonProperty("T$CMNF")]
        [Column("T$CMNF")]
        public string TCMNF { get; set; }

        [JsonProperty("T$CSEL")]
        [Column("T$CSEL")]
        public string TCSEL { get; set; }

        [JsonProperty("T$CSIG")]
        [Column("T$CSIG")]
        public string TCSIG { get; set; }

        [JsonProperty("T$RDPT")]
        [Column("T$RDPT")]
        public string TRDPT { get; set; }

        [JsonProperty("T$CTYO")]
        [Column("T$CTYO")]
        public string TCTYO { get; set; }

        [JsonProperty("T$ENVC")]
        [Column("T$ENVC")]
        public int? TENVC { get; set; }

        [JsonProperty("T$CEAN")]
        [Column("T$CEAN")]
        public string TCEAN { get; set; }

        [JsonProperty("T$CCDE")]
        [Column("T$CCDE")]
        public string TCCDE { get; set; }

        [JsonProperty("T$ICSI")]
        [Column("T$ICSI")]
        public int? TICSI { get; set; }

        [JsonProperty("T$PSIU")]
        [Column("T$PSIU")]
        public int? TPSIU { get; set; }

        [JsonProperty("T$STYP")]
        [Column("T$STYP")]
        public int? TSTYP { get; set; }

        [JsonProperty("T$SUBC")]
        [Column("T$SUBC")]
        public int? TSUBC { get; set; }

        [JsonProperty("T$OKTM")]
        [Column("T$OKTM")]
        public Int64? TOKTM { get; set; }

        [JsonProperty("T$DPCR")]
        [Column("T$DPCR")]
        public int? TDPCR { get; set; }

        [JsonProperty("T$TXTA")]
        [Column("T$TXTA")]
        public string TTXTA { get; set; }

        [JsonProperty("T$CDF_BATP")]
        [Column("T$CDF_BATP")]
        public string TCDF_BATP { get; set; }

        [JsonProperty("T$REFCNTD")]
        [Column("T$REFCNTD")]
        public int? TREFCNTD { get; set; }

        [JsonProperty("T$REFCNTU")]
        [Column("T$REFCNTU")]
        public int? TREFCNTU { get; set; }

    }

}