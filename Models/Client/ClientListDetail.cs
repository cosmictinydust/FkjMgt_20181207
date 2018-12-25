using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.Models.Client
{
    public class ClientListDetail
    {
        public int Id { get; set; }
        public Int16 IsOld { get; set; }
        public int EmployeeID_xf { get; set; }
        public int ClientID_From101 { get; set; }
        public int ClientID_FromXF { get; set; }
        public string ClientName { get; set; }
        [DisplayFormat(DataFormatString ="{0:N0}")]
        public decimal SellSum { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal CostSum { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal ProfitSum { get; set; }
        public string EmpName { get; set; }
        public string YearMonth { get; set; }
        public string FistDate { get; set; }
        public string LinkMan { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }
        public int CallBackCount { get; set; }
    }
}
