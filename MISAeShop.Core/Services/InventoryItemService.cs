using MISAeShop.Core.Entities;
using MISAeShop.Core.Interfaces.Repository;
using MISAeShop.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Services
{   
    /// <summary>
    /// Service hàng hóa
    /// </summary>
    public class InventoryItemService: BaseService<InventoryItem>, IInventoryItemService
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="inventoryItemRepository"></param>
        public InventoryItemService(IInventoryItemRepository inventoryItemRepository):base(inventoryItemRepository)
        {

        }
    }
}
