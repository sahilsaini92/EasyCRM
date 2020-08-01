using EasyCRM.ViewModels.Inventory;
using EasyCRM.ViewModels.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.Services.Interfaces
{
    public interface IService
    {
        IPagedList<InventoryItemIndexViewModel> GetAllServices(string search, int? i);

        int CreateServiceAsync(InventoryItemCreateViewModel item);

        Task<InventoryItemCreateViewModel> EditServiceAsync(int id);

        int EditServiceAsync(InventoryItemCreateViewModel item);

        InventoryItemDetailsViewModel ServiceDetails(int id);

        QuoteItemViewModel ServiceItems(int? serviceId = 0);

    }
}
