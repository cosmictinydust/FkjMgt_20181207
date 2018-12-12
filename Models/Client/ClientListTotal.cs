using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.Models.Client
{
    public class ClientListTotal
    {
        public int id { get; set; }
        public int EmployeeID_xf { get; set; }
        public decimal SellSum { get; set; }
        public decimal CostSum { get; set; }
        public decimal ProfitSum { get; set; }
    }
}
