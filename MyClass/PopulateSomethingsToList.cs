using FkjMgt_20181207.Data;
using FkjMgt_20181207.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FkjMgt_20181207.MyClass
{
    public class PopulateSomethingsToList
    {
        private ApplicationDbContext _contextWebServer;
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
    }
}
