using EasyCRM.Entities.DataConnection;
using EasyCRM.Services.Employees;
using EasyCRM.ViewModels.Employees;
using EasyCRM.ViewModels.Inventory;
using EasyCRM.ViewModels.Login;
using EasyCRM.ViewModels.Settings;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(string search, int? i)
        {
            using (var context = new EasyCRMDBContext())
            {
                var items = context.Employee
                    .Select(x => new EmployeeIndexViewModel()
                    {
                        ID = x.ID,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        EmergencyContactPerson = x.EmergencyContactPerson,
                        EmergencyContactPersonPhone = x.EmergencyContactPersonPhone,
                        DateOfBirth = x.DateOfBirth,
                        Phone = x.Phone,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate
                    }).ToList().ToPagedList(i ?? 1, 10);
                return View(items);
            }
        }

        public ActionResult Create()
        {
            EmployeeCreateViewModel vm = new EmployeeCreateViewModel();
            //AddressCreateViewModel addressVm = new AddressCreateViewModel();
            //vm.Address = addressVm;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreateViewModel viewModel)
        {
            EmployeeCreateService empService = new EmployeeCreateService();
            var employee = empService.CreateEmployeeAsync(viewModel);
            return View();
        }

        [HttpGet]
        public ActionResult Address([Bind(Prefix = "Address")] AddressCreateViewModel viewModel)
        {
            ViewData.TemplateInfo.HtmlFieldPrefix = string.Format("Address");
            return PartialView("~/Views/Shared/EditorTemplates/_address.cshtml", viewModel);
        }

        public ActionResult AddressEditor()
        {
            AddressCreateViewModel viewModel = new AddressCreateViewModel();
            return PartialView("~/Views/Shared/EditorTemplates/_address.cshtml", viewModel);
        }
    }
}