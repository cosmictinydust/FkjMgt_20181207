﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FkjMgt_20181207.Models;
using FkjMgt_20181207.Models.Client;
using FkjMgt_20181207.Data;
using Microsoft.EntityFrameworkCore;

namespace FkjMgt_20181207.Controllers
{
    public class ClientController : Controller
    {
        private readonly XfDbContext _context;
        public ClientController(XfDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SellClientAuthoSeller()
        {
            //var dataShow = new List<ClientListViewModel>();
            string StrQuery;
            StrQuery = string.Format("EXECUTE [dbo].[clientReward_QueryResult]  @yearMonthSet = N'201812'");
            //dataShow = _context.Set<ClientListViewModel>().FromSql(StrQuery).ToList();
            var clientDataset = new ClientListDatasetViewModels();


            clientDataset.clientListDetails = await _context.Set<ClientListDetail>().FromSql(StrQuery).ToListAsync();
            
            //var clientTotal = clientDataset.clientListDetails.GroupBy(emp => Math.Floor(emp.SellSum), emp => emp.EmployeeID_xf, (baseage, ags) => new
            //{
            //    key = baseage,
            //    count = ags.Count(),
            //    sum = ags.Sum()
            //});
            var grouped = clientDataset.clientListDetails.GroupBy(x => x.EmployeeID_xf);
            clientDataset.clientListTotals = grouped.Select(s => new ClientListTotal { EmployeeID_xf = s.Key, SellSum = s.Sum(t => t.SellSum), CostSum = s.Sum(t => t.CostSum), ProfitSum = s.Sum(t => t.ProfitSum) });

            return View(clientDataset);
        }
    }
}