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
        /// <summary>
        /// 取所有部门列表
        /// </summary>
        static public IEnumerable<SelectListItem> PopulateDeparList(ApplicationDbContext context)
        {
            var returnList= context.DeparList.ToList().Select(r => new SelectListItem
            {
                Text = r.DeparName,
                Value = r.Id_xf.ToString()
            });
            return returnList;
        }

        /// <summary>
        /// 取所有业务员列表
        /// </summary>
        static public IEnumerable<SelectListItem> PopulateEmpList(ApplicationDbContext context)
        {
            var returnList = context.EmpList.ToList().Select(s => new SelectListItem
            {
                Text = s.EmpName,
                Value = s.Id_xf.ToString()
            });
            return returnList;
        }
        /// <summary>
        /// 取指定部门的业务员列表
        /// </summary>
        static public IEnumerable<SelectListItem> PopulateEmpList(ApplicationDbContext context,int deparID)
        {
            var returnList= context.EmpList.ToList().Where(w => w.DeparId_xf == deparID).Select(s => new SelectListItem
            {
                Text = s.EmpName,
                Value = s.Id_xf.ToString()
            });
            return returnList;
        }
    }
   

}

