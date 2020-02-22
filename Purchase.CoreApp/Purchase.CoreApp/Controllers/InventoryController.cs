using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Purchase.CoreApp.Models;
using Purchase.CoreApp.Services;

namespace Purchase.CoreApp.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _service;
        public InventoryController(IInventoryService services)
        {
            _service = services;
        }
        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AdInventoryItems(InventoryItems items)
        {
            var inventoryItems = _service.AddInventoryItems(items);
            if (inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }

        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string, InventoryItems>> GetInventoryItems()
        {
            var inventoryItems = _service.GetInventoryItems();

            if(inventoryItems.Count == 0)
            {
                return NotFound();
            }
            return inventoryItems;
        }
    }
}