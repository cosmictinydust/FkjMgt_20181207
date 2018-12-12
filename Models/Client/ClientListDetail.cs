using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.Models.Client
{
    public class ClientListDetail
    {
        public int Id { get; set; }
        public int EmployeeID_xf { get; set; }
        public int ClientID_From101 { get; set; }
        public int ClientID_FromXF { get; set; }
        public string ClientName { get; set; }
        public decimal SellSum { get; set; }
        public decimal CostSum { get; set; }
        public decimal ProfitSum { get; set; }
        public string EmpName { get; set; }
        public string YearMonth { get; set; }
        public string FistDate { get; set; }
        public string LinkMan { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
    }
}
