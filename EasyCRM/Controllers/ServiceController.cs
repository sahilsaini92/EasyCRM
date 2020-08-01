using EasyCRM.Services.Interfaces;
using EasyCRM.Services.Service;
using EasyCRM.ViewModels.Inventory;
using EasyCRM.ViewModels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.Controllers
{
    public class ServiceController : Controller
    {

        IService _repository;

        public ServiceController() : this(new ServiceRepository()) { }

        public ServiceController(IService repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ServiceCreateViewModel viewModel = new ServiceCreateViewModel();
            viewModel.Items = _repository.ServiceItems(null);
            return View(viewModel);
        }
    }
}