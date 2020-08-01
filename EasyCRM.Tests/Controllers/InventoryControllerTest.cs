using System;
using System.Web.Mvc;
using System.Web.Routing;
using EasyCRM.Controllers;
using EasyCRM.Services.Interfaces.Inventory;
using EasyCRM.Services.Inventory;
using EasyCRM.ViewModels.Inventory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyCRM.Tests.Controllers
{
    [TestClass]
    public class InventoryControllerTest
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
        }

    }
}
