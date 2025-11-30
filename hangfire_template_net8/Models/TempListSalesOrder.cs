using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{

    public class HeaderSalesOrder
    {
        public string SALES_ORDER { get; set; }

    }


    [Table("temp_dashboard_linechart_sales_order")]
    public class TempDashboardLineChartSalesOrder
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? id { get; set; }
        public int? year { get; set; }
        public int? month_sort { get; set; }
        public string month_desc { get; set; }
        public Decimal? delivered_uninvoice { get; set; }
        public Decimal? delivered_invoiced { get; set; }
        public Decimal? undelivered { get; set; }
        public Decimal? cancel_so { get; set; }
        public Decimal? avg_value { get; set; }
    }

    public class Delivered_Uninvoiced
    {
        public int? YEAR { get; set; }
        public int? MONTH { get; set; }
        public Decimal DELIVERED_UNINVOICED  { get; set; }
    } 
    
    public class Delivered_Invoiced
    {
        public int? YEAR { get; set; }
        public int? MONTH { get; set; }
        public Decimal DELIVERED_INVOICED  { get; set; }
    }

    public class UnDelivered
    {
        public int? YEAR { get; set; }
        public int? MONTH { get; set; }
        public Decimal UNDELIVERED { get; set; }
    }
    
    public class Canceled
    {
        public int? YEAR { get; set; }
        public int? MONTH { get; set; }
        public Decimal CANCELED { get; set; }
    }

    public class AVERAGE
    {
        public int? YEAR { get; set; }
        public int? MONTH { get; set; }
        public Decimal AVG { get; set; }
    }

    public class MODEL_PROCESS_CALCULATE
    {
        public string SALES_ORDER { get; set; }
        public int? LINE { get; set; }
        public int? SEQUENCE { get; set; }
        public int? QTY { get; set; }
        public Decimal PRICE { get; set; }
    }
}