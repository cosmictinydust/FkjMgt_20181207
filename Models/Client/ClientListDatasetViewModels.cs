using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.Models.Client
{
    public class ClientListDatasetViewModels
    {
        [BindProperty]
        public string DeparID { get; set; }
        [BindProperty]
        public string EmpID { get; set; }
        [BindProperty]
        public string CurrentMonth { get; set; }
        public IEnumerable<SelectListItem> DeparLists { get; set; }
        public IEnumerable<SelectListItem> EmpLists { get; set; }
        public List<SelectListItem> YearMonth { get; set; }
        public IEnumerable<ClientListDetail> clientListDetails { get; set; }
        public IEnumerable<ClientListTotal> clientListTotals { get; set; }

        public ClientListDatasetViewModels(Data.ApplicationDbContext context)
        {
            DeparLists = MyClass.PopulateSomethingsToList.PopulateDeparList(context);
            string TobeYM = "";
            //for (int i=0;i>=-2;i--)
            //{
            //    TobeYM = DateTime.Now.AddMonths(i).ToString("YYYYMM");
            //    YearMonth.Add(new SelectListItem { Value = TobeYM, Text = TobeYM });
            //}
            var Tobe = new SelectListItem { Value = "0", Text = "abc" };
            YearMonth.Add(Tobe);
        }
    }
}
