using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_temp_listcustomer")]
    public class TempListCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64? id_recnum_listcustomer { get; set; }
        public string id_bisnis_partner { get; set; }        
        public string nama { get; set; }        
        public string search_key { get; set; }       
        public string currency { get; set; }
        public string language_bp { get; set; }  
        public DateTime? start_date_join { get; set; }        
        public DateTime? end_date_join { get; set; } 
        public DateTime? insert_date { get; set; }
        public DateTime? update_date { get; set; }
        public DateTime? check_fire_date { get; set; }
    }

    public class DetailMappingListCustomerModel
    {
        public string id_bisnis_partner { get; set; }
        public string nama { get; set; }
        public string search_key { get; set; }
        public string currency { get; set; }
        public string language_bp { get; set; }
        public DateTime? start_date_join { get; set; }
        public DateTime? end_date_join { get; set; }
        public DateTime? insert_date { get; set; }
        public DateTime? update_date { get; set; }
        public DateTime? check_fire_date { get; set; }

    }
}