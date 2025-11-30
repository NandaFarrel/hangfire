using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hangfire_template.Models
{
    [Table("t_gscpl1121m000")]
    public class TempListCapacityPlanning
    {
        public int Company { get; set; }        
        public string Plan_Id { get; set; }        
        public int Yearr { get; set; }       
        public int Period { get; set; }
        public string MPS_Status { get; set; }  
        public string Consider_Stock { get; set; }  
        public int Calender_Days { get; set; }  
        public int Working_Days { get; set; }  
        public int Holiday { get; set; }  
        public string Remarks { get; set; }  
        public string Created_By { get; set; }  
        public DateTime? Created_Date { get; set; }  
        public string Created { get; set; }  
        public string Confirmed_By { get; set; }  
        public DateTime? Confirmed_Date { get; set; }  
        public string Confirmed { get; set; }  
        public string Item { get; set; }  
        public string Description { get; set; }  
        public string Site { get; set; }  
        public DateTime? Delivery_Date { get; set; }  
        public DateTime? Schedule_Date { get; set; }  
        public int Lead_Time { get; set; }  
        public int Total_Demand { get; set; }  
        public int Allocated { get; set; }  
        public int Balance_Qty { get; set; }  
        public int Available_Stock { get; set; }  
        public int Net_Requirement { get; set; }  
        public int Lot_Extra { get; set; }  
        public int Lot_Size { get; set; }  
        public string Remark { get; set; }  
    }
}









