using EasyCRM.ViewModels.Inventory;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.Services.Interfaces.Inventory
{
    public interface IInventoryItem
    {
        IPagedList<InventoryItemIndexViewModel> GetAllInventoryItems(string search, int? i);

        int CreateInventoryItemAsync(InventoryItemCreateViewModel item);

        Task<InventoryItemCreateViewModel> EditInventoryItemAsync(int id);

        int EditInventoryItemAsync(InventoryItemCreateViewModel item);

        InventoryItemDetailsViewModel CreateItemDetails(int id);

        IPagedList<StockItemIndexViewModel> GetAllItemStocks(string search, int? i);

        Task<int> AddStockAsync(AddStockViewModel item);
    }
}
