using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FkjMgt_20181207.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FkjMgt_20181207.Models
{
    public class QueryItemsViewModel
    {
        //private ApplicationDbContext _contextWebServer;
        //public QueryItemsViewModel(ApplicationDbContext context)
        //{
        //    _contextWebServer = context;
        //    DeparLists= context.DeparList.ToList().Select(r=>new SelectListItem {
        //        Text=r.DeparName,Value=r.Id_xf.ToString()
        //    }) ;
        //}
        public string DeparName { get; set; }
        public string EmpName { get; set; }
        public IEnumerable<SelectListItem> DeparLists { get; set; } 
        public IEnumerable<SelectListItem> EmpLists { get; set; }

        
    }
}
