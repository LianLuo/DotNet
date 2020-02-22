using Purchase.CoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purchase.CoreApp.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly Dictionary<string, InventoryItems> _inventoryDic;

        public InventoryService()
        {
            _inventoryDic = new Dictionary<string, InventoryItems>();
        }
        public InventoryItems AddInventoryItems(InventoryItems items)
        {
            _inventoryDic.Add(items.InventoryName, items);
            return items;
        }

        public Dictionary<string, InventoryItems> GetInventoryItems()
        {
            return _inventoryDic;
        }
    }
}
