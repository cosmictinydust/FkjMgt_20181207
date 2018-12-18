using FkjMgt_20181207.Data;
using FkjMgt_20181207.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.MyClass
{
    public class PopulateSomethingsToList
    {
        private readonly ApplicationDbContext _contextWebServer;
        public PopulateSomethingsToList(ApplicationDbContext ContextWebServer)
        {
            _contextWebServer = ContextWebServer;
        }

        static public SelectList PopulateDeparList(ApplicationDbContext ContextWebServer,object selectedDepar=null)
        {
            var deparlists = from tempData in ContextWebServer.DeparList orderby tempData.DispOrder select tempData;
            var MyReturn = new SelectList(deparlists, "Id_xf", "DeparName", selectedDepar);
            return MyReturn;
        }
        static public QueryItemsViewModel PopulationQueryItem(ApplicationDbContext ContextWebServer)
        {
            var returnModel = new QueryItemsViewModel();
            returnModel.DeparLists = ContextWebServer.DeparList.ToList().Select(r => new SelectListItem
            {
                Text = r.DeparName,
                Value = r.Id_xf.ToString()
            });
                //returnModel.EmpLists = ContextWebServer.EmpList.ToList();
            return returnModel;
        }
    }

    
    public class DeparListSelection
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public string DeparName { get; set; }
        public IEnumerable<SelectListItem> DeparLists { get; }

        public DeparListSelection(ApplicationDbContext context)
        {
            DeparLists= context.DeparList.ToList().Select(r => new SelectListItem
            {
                Text = r.DeparName,
                Value = r.Id_xf.ToString()
            });
        }
    }
}

