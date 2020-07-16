using EasyCRM.Entities.DataConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyCRM.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly EasyCRMDBContext context;

        public BaseController(EasyCRMDBContext context)
        {
            this.context = context;
        }
        
    }
}