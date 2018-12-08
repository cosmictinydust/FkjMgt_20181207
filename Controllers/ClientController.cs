﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FkjMgt_20181207.Models;
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
        public IActionResult SellClientAuthoSeller()
        {
            var dataShow = new List<ClientListViewModel>();
            string StrQuery;
            StrQuery = string.Format("EXECUTE [dbo].[clientReward_QueryResult]  @yearMonthSet = N'201812'");
            dataShow = _context.Set<ClientListViewModel>().FromSql(StrQuery).ToList();
            return View(dataShow);
        }
    }
}