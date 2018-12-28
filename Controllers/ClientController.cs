using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FkjMgt_20181207.Models;
using FkjMgt_20181207.Models.Client;
using FkjMgt_20181207.Data;
using Microsoft.EntityFrameworkCore;
using FkjMgt_20181207.MyClass;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FkjMgt_20181207.Controllers
{
    public class ClientController : Controller
    {
        private readonly XfDbContext _contextXf;
        private readonly ApplicationDbContext _contextServer;
        public ClientController(XfDbContext context, ApplicationDbContext context1)
        {
            _contextXf = context;
            _contextServer = context1;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult SellClientAuthoSeller()
        {
            ClientListDatasetViewModels clientDataset = new ClientListDatasetViewModels(_contextServer);
             return View(clientDataset);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SellClientAuthoSeller(string deparID,string empID,string currentMonth,string searchName)
        {
            string StrQuery;
            currentMonth = currentMonth is null ? "''" : currentMonth;
            searchName = searchName is null ? "''" : searchName;
            StrQuery = string.Format("EXECUTE [dbo].[clientReward_QueryResult]  @yearMonthSet = {0},@deparID={1},@empID={2},@clientNamePart={3}", currentMonth,deparID,empID,searchName);
            var clientDataset = new ClientListDatasetViewModels(_contextServer);

            clientDataset.clientListDetails = await _contextXf.Set<ClientListDetail>().FromSql(StrQuery).ToListAsync();

            var grouped = clientDataset.clientListDetails.GroupBy(x => x.EmployeeID_xf);

            clientDataset.clientListTotals = grouped.Select(s =>
                new ClientListTotal
                {
                    EmployeeID_xf = s.Key,
                    SellSum = s.Sum(t => t.SellSum),
                    CostSum = s.Sum(t => t.CostSum),
                    ProfitSum = s.Sum(t => t.ProfitSum),
                    EmpName = s.Max(t => t.EmpName),
                    ResultSum = s.Sum(t => t.ProfitSum) * (decimal)0.05
                });
            clientDataset.DeparID = deparID;
            clientDataset.EmpID = empID;
            clientDataset.CurrentMonth = currentMonth;
            clientDataset.EmpLists = MyClass.PopulateSomethingsToList.PopulateEmpList(_contextServer, Convert.ToInt16(deparID));
            return View(clientDataset);
        }

        public IActionResult GetEmpFromDepar(string deparID)
        {
            ClientListDatasetViewModels returnModel = new ClientListDatasetViewModels(_contextServer);
            returnModel.EmpLists=MyClass.PopulateSomethingsToList.PopulateEmpList(_contextServer, Convert.ToInt16(deparID));
            return PartialView("PartialEmployeeListView",returnModel);
        }

        public async Task<IActionResult> GetClientInfoById(int? id)
        {
            //var strQuery = string.Format("SELECT id AS ClientID,ISNULL(联系人,'') AS LinkMan,ISNULL(联系电话,'') AS ContactPhone,ISNULL(联系地址,'') AS ContactAdress FROM clientlist WHERE id="+id.ToString());
            //var resultData = await _contextXf.Set<CallbackList>().FromSql(strQuery).FirstOrDefaultAsync();
            var resultData = await _contextXf.ClientInfo.FromSql($"SELECT id AS ClientID,ISNULL(联系人,'') AS LinkMan,ISNULL(联系电话,'') AS ContactPhone,ISNULL(联系地址,'') AS ContactAdress FROM clientlist WHERE id={id}").FirstOrDefaultAsync();
            ViewBag.linkMan = resultData.LinkMan.ToString().TrimEnd();
            ViewBag.contactPhone = resultData.ContactPhone.ToString().TrimEnd();
            ViewBag.contactAdress = resultData.ContactAdress.ToString().TrimEnd();
            ViewBag.Callbacks = await _contextXf.CallbackList.FromSql($"SELECT  id, ClientID, DataType, recordDate, MemoInfo FROM clientRewardCallbackList WHERE ClientID={id}").ToListAsync();
            return PartialView("PartialClientShowDetail");
        }
    }
}