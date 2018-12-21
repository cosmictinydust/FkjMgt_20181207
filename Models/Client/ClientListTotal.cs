using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.Models.Client
{
    public class ClientListTotal
    {
        public int id { get; set; }
        public int EmployeeID_xf { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal SellSum { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal CostSum { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal ProfitSum { get; set; }
        public string EmpName { get; set; }
        [DisplayFormat(DataFormatString = "{0:N}")]
        public decimal ResultSum { get; set; }
    }
}
