using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EasyCRM;
using EasyCRM.Controllers;
using EasyCRM.Services.Inventory;
using EasyCRM.ViewModels.Inventory;
using EasyCRM.Entities.Inventory;

namespace EasyCRM.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            InventoryCreateService service = new InventoryCreateService();
            InventoryItemCreateViewModel vm = new InventoryItemCreateViewModel();
            vm.PartName = "Test 9";
            vm.PartNumber = "Test 9";
            vm.CreatedDate = DateTime.UtcNow;
            service.CreateInventoryItemAsync(vm,null);
          //  IEnumerable<InventoryItem> employees = emprepository.GetAllEmployee();
            //Assert.IsTrue(employees.Contains(employee));
        }
    }
}
