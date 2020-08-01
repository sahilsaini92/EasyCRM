using EasyCRM.Entities.DataConnection;
using EasyCRM.Entities.Inventory;
using EasyCRM.Entities.Login;
using EasyCRM.Services.Interfaces.Inventory;
using EasyCRM.ViewModels.Employees;
using EasyCRM.ViewModels.Inventory;
using EasyCRM.ViewModels.Login;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.Services.Inventory
{
    public class IMemoryInventoryCreateService : IInventoryItem
    {
        private EasyCRMDBContext db = new EasyCRMDBContext();

        public IPagedList<InventoryItemIndexViewModel> GetAllInventoryItems(string search, int? i)
        {
            try
            {
                var items = db.InventoryItem.Where(x => x.PartName.StartsWith(search) || search == null)
                        .Select(x => new InventoryItemIndexViewModel()
                        {
                            ID = x.ID,
                            PartName = x.PartName,
                            PartNumber = x.PartNumber,
                            CreatedBy = x.CreatedBy,
                            CreatedDate = x.CreatedDate
                        }).ToList().ToPagedList(i ?? 1, 10);
                return items;
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public int CreateInventoryItemAsync(InventoryItemCreateViewModel item,HttpPostedFileBase files)
        {
            try
            {
                EasyCRM.Entities.Inventory.InventoryItem inventoryItem = new EasyCRM.Entities.Inventory.InventoryItem();
                var isExist = db.InventoryItem.Any(ii => ii.PartName == item.PartName);
                if (isExist)
                {
                    return 0;
                }
                inventoryItem.PartName = item.PartName;
                inventoryItem.PartNumber = item.PartNumber;
                inventoryItem.CreatedDate = DateTime.UtcNow;
                inventoryItem.LastModifiedDate = DateTime.UtcNow;
                inventoryItem.CreatedBy = item.CreatedBy;
                inventoryItem.Modifiedby = item.Modifiedby;
                inventoryItem.Image = ConvertToBytes(files);
                db.InventoryItem.Add(inventoryItem);
                db.SaveChanges();
                return inventoryItem.ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<InventoryItemCreateViewModel> EditInventoryItemAsync(int id)
        {
            try
            {
                InventoryItemCreateViewModel vm = new InventoryItemCreateViewModel();
                var dbItem = await db.InventoryItem.Where(ii => ii.ID == id).FirstOrDefaultAsync();
                vm.PartName = dbItem.PartName;
                vm.PartNumber = dbItem.PartNumber;
                vm.LastModifiedDate = dbItem.LastModifiedDate;
                vm.Modifiedby = dbItem.Modifiedby;
                return vm;
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public int EditInventoryItemAsync(InventoryItemCreateViewModel item)
        {
            try
            {
                var dbItem = db.InventoryItem.Where(ii => ii.ID == item.ID).FirstOrDefault();
                var isExist = db.InventoryItem.Where(ii => ii.PartName.ToLower() == item.PartName.ToLower() && ii.ID != item.ID).Count();
                if (isExist >= 1)
                {
                    return 0;
                }
                dbItem.PartName = item.PartName;
                dbItem.PartNumber = item.PartNumber;
                dbItem.LastModifiedDate = DateTime.UtcNow;
                dbItem.Modifiedby = item.Modifiedby;
                db.Entry(dbItem).State = EntityState.Modified;
                db.SaveChanges();
                return dbItem.ID;
            }
            catch (Exception exp)
            {
                return 0;
            }
        }

        public async Task<AddStockViewModel> AddStock()
        {
            AddStockViewModel stockViewModel = new AddStockViewModel();
            var enumData = from Source e in Enum.GetValues(typeof(Source))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            var selectList = new SelectList(enumData, "ID", "Name");
            stockViewModel.SourceList = selectList;
            var lst = await db.InventoryItem.ToListAsync();
            IEnumerable<SelectListItem> itemList = lst
                .Select(list => new SelectListItem()
                { Text = list.PartName + "-" + list.PartNumber, Value = list.ID.ToString() });
            var i = db.InventoryItem.ToListAsync();
            stockViewModel.ItemList = new SelectList(itemList, "Value", "Text");
            return stockViewModel;
        }

        public async Task<int> AddStockAsync(AddStockViewModel item)
        {
            try
            {
                // using (var dbContext = new EasyCRMDBContext())
                // {
                Stocks stockItem = new Stocks();
                var stockDetail = db.Stocks.Where(i => i.ItemID == item.ItemId).FirstOrDefault();
                if (stockDetail == null)
                {
                    if (item.To == Source.ServiceStation)
                    {
                        stockItem.ServiceStationStock = item.Quantity;
                    }
                    else
                    {
                        stockItem.WarehouseStock = item.Quantity;
                    }
                    stockItem.CreatedDate = DateTime.UtcNow;
                    stockItem.Price = item.Price;
                    stockItem.LastModifiedDate = DateTime.UtcNow;
                    stockItem.SalePrice = item.SalePrice;
                    stockItem.From = item.From;
                    stockItem.To = item.To;
                    stockItem.CreatedBy = item.CreatedBy;
                    stockItem.Modifiedby = item.Modifiedby;
                    stockItem.CreatedBy = item.CreatedBy;
                    stockItem.Modifiedby = item.Modifiedby;
                    stockItem.RackNumber = item.RackNumber;
                    stockItem.Item = db.InventoryItem.Where(i => i.ID == item.ItemId).FirstOrDefault();
                    db.Stocks.Add(stockItem);
                    db.SaveChanges();
                }
                else
                {
                    if (item.To == Source.ServiceStation)
                    {
                        if (item.From == Source.WareHouse)
                        {
                            stockDetail.WarehouseStock = stockDetail.WarehouseStock - item.Quantity;
                        }
                        stockDetail.ServiceStationStock = stockDetail.ServiceStationStock + item.Quantity;
                        stockDetail.RackNumber = item.RackNumber;
                    }
                    else
                    {
                        if (item.From == Source.ServiceStation)
                        {
                            stockDetail.ServiceStationStock = stockDetail.ServiceStationStock - item.Quantity;
                        }
                        stockDetail.WarehouseStock = stockDetail.WarehouseStock + item.Quantity;
                    }
                    stockDetail.CreatedDate = DateTime.UtcNow;
                    stockDetail.Price = item.Price;
                    stockDetail.LastModifiedDate = DateTime.UtcNow;
                    stockDetail.SalePrice = item.SalePrice;
                    stockDetail.From = item.From;
                    stockDetail.To = item.To;
                    stockDetail.CreatedBy = item.CreatedBy;
                    stockDetail.Modifiedby = item.Modifiedby;
                    stockDetail.CreatedBy = item.CreatedBy;
                    stockDetail.Modifiedby = item.Modifiedby;
                    stockDetail.Item = db.InventoryItem.Where(i => i.ID == item.ItemId).FirstOrDefault();
                    db.Entry(stockDetail).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }

                return stockItem.ID;
                // }
            }
            catch (Exception exp)
            {
                return 0;
            }

        }

        public InventoryItemDetailsViewModel CreateItemDetails(int id)
        {
            try
            {
                var itemDetail = db.InventoryItem.Where(ii => ii.ID == id).Select(ii => new InventoryItemDetailsViewModel()
                {
                    ID = ii.ID,
                    PartName = ii.PartName,
                    PartNumber = ii.PartNumber
                }).FirstOrDefault();
                return itemDetail;
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public IPagedList<StockItemIndexViewModel> GetAllItemStocks(string search, int? i)
        {
            try
            {
                var items = db.Stocks
                        .Select(x => new StockItemIndexViewModel()
                        {
                            ID = x.ID,
                            PartName = x.Item.PartName,
                            PartNumber = x.Item.PartNumber,
                            StockAavilableinServiceStation = x.ServiceStationStock,
                            StockAavilableinWareHouse = x.WarehouseStock,
                            Price = x.Price,
                            SalePrice = x.SalePrice,
                            RackNumber = x.RackNumber,
                            Source = x.From,
                            CreatedBy = x.CreatedBy,
                            CreatedDate = x.CreatedDate
                        }).ToList().ToPagedList(i ?? 1, 10);
                return items;
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }



    }
}