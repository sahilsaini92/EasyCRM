using EasyCRM.Entities.Inventory;
using EasyCRM.Services.Inventory;
using EasyCRM.ViewModels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EasyCRM.Entities.DataConnection;
using System.Threading.Tasks;
using EasyCRM.Services.Interfaces.Inventory;

namespace EasyCRM.Controllers
{
    public class InventoryController : Controller
    {

        IInventoryItem _repository;

        public InventoryController() : this(new InventoryCreateService()) { }

        public InventoryController(IInventoryItem repository)
        {
            _repository = repository;
        }
        public ActionResult Index(string search, int? i)
        {
            var items = _repository.GetAllInventoryItems(search, i);
            return View(items);
        }


        public ActionResult Create()
        {
            InventoryItemCreateViewModel vm = new InventoryItemCreateViewModel();
            return View(vm);
        }

        public async Task<ActionResult> Edit(int id)
        {
            InventoryItemCreateViewModel vm = new InventoryItemCreateViewModel();
            vm = await _repository.EditInventoryItemAsync(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(InventoryItemCreateViewModel vm)
        {
            var id = _repository.EditInventoryItemAsync(vm);
            if (id == 0)
            {
                ModelState.AddModelError("PartName", "Item with this name already exists!");
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AddStock()
        {
            AddStockViewModel vm = new AddStockViewModel();
            InventoryCreateService service = new InventoryCreateService();
            vm = await service.AddStock();
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddStock(AddStockViewModel vm)
        {
            var item = _repository.AddStockAsync(vm);
            return RedirectToAction("StockList");
        }

        public ActionResult StockList(string search, int? i)
        {
            var items = _repository.GetAllItemStocks(search, i);
            return View(items);
        }

        [HttpPost]
        public ActionResult Create(InventoryItemCreateViewModel vm)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            var id = _repository.CreateInventoryItemAsync(vm,file);
            if (id == 0)
            {
                ModelState.AddModelError("PartName", "Item with this name already exists!");
                return View(vm);
            }
            return RedirectToAction("Edit", new { id = id });
        }

        public ActionResult Details(int id)
        {
            var details = _repository.CreateItemDetails(id);
            return View(details);
        }
    }
}