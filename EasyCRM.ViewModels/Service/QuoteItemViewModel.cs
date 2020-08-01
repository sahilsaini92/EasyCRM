using EasyCRM.Entities.Inventory;
using EasyCRM.Entities.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.ViewModels.Service
{
    public class QuoteItemViewModel
    {
        private List<ServiceCreateItemsViewModel> _items;

        public List<ServiceCreateItemsViewModel> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = new List<ServiceCreateItemsViewModel>();
            }

        }

    }

}