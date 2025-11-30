using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{

    public class DataMysql
    {
        public string id { get; set; }
        public string code { get; set; }
        public string number { get; set; }
        public string ip_address { get; set; }
    }


    [Table("t_temp_listbudget")]
    public class TempListBudget
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64? id_recnum_listbudget { get; set; }
        public string dim1 { get; set; }        
        public string dim2 { get; set; }        
        public string dim6 { get; set; }       
        public int? budget_year { get; set; }
        public string account_budget { get; set; }
        public string description_budget { get; set; }  
        
        //[Column(TypeName = "decimal(30,7)")]
        public decimal? budget_amount { get; set; }        
        public decimal? saldo { get; set; }        
        public string requisition { get; set; }
        public DateTime? requisition_date { get; set; }        
        public string requester_department { get; set; }
        public string purchase_order { get; set; }

        //[Column(TypeName = "decimal(30,7)")]
        public decimal? order_amount { get; set; }
        public DateTime? order_date { get; set; }
        public string rfq { get; set; }
        public DateTime insert_date { get; set; }
        public DateTime update_date { get; set; }
        public DateTime check_fire_date { get; set; }
    }

    public class MapTempListBudget
    {
        public List<TempListBudget> tempListBudget { get; set; } = new List<TempListBudget>();
    }

    public class DetailMappingListBudgetFinanceModel
    {
        public string requisition { get; set; }
        public int budget_year { get; set; }
        public string account_budget { get; set; }
        public string description_budget { get; set; }
        public string dim1 { get; set; }
        public string dim2 { get; set; }
        public string dim6 { get; set; }

        public decimal? budget_amount { get; set; }
        public decimal saldo { get; set; }

        public decimal? order_amount { get; set; }

        //public double avai { get; set; }
        public string purchase_order { get; set; }
        public string rfq { get; set; }
        public DateTime? requisition_date { get; set; }
        public string requester_department { get; set; }
        //public string latest_transaction { get; set; }
        public string requested_date { get; set; }
        public DateTime? order_date { get; set; }
        //public string rate_date { get; set; }
        //public string receipt_date { get; set; }

    }
}