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
        public IEnumerable<SelectListItem> DeparLists { get; set; }
        public IEnumerable<SelectListItem> EmpLists { get; set; }
        public IEnumerable<ClientListDetail> clientListDetails { get; set; }
        public IEnumerable<ClientListTotal> clientListTotals { get; set; }

        public ClientListDatasetViewModels(Data.ApplicationDbContext context)
        {
            DeparLists = MyClass.PopulateSomethingsToList.PopulateDeparList(context);
        }
    }
}
