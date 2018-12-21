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
        [BindProperty]
        public string SearchName { get; set; } 
        public IEnumerable<SelectListItem> DeparLists { get; set; }
        public IEnumerable<SelectListItem> EmpLists { get; set; }
        public IEnumerable<SelectListItem> YearMonths { get; set; }
        public IEnumerable<ClientListDetail> clientListDetails { get; set; }
        public IEnumerable<ClientListTotal> clientListTotals { get; set; }

        public ClientListDatasetViewModels(Data.ApplicationDbContext context)
        {
            DeparID = "0";EmpID = "0";CurrentMonth = "";SearchName = "";
            DeparLists = MyClass.PopulateSomethingsToList.PopulateDeparList(context);
            List<SelectListItem> TobeAdd = new List<SelectListItem>();
            string TobeYM = "";
            for (int i = 0; i >= -5; i--)
            {
                TobeYM = DateTime.Now.AddMonths(i).ToString("yyyyMM");
                TobeAdd.Add(new SelectListItem { Value = TobeYM, Text = TobeYM });
            }
            YearMonths = TobeAdd;
        }
    }
}
