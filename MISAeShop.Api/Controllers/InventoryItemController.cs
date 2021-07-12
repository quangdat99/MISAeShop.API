using Microsoft.AspNetCore.Mvc;
using MISAeShop.Core.Entities;
using MISAeShop.Core.Interfaces.Repository;
using MISAeShop.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAeShop.Api.Controllers
{
    /// <summary>
    /// Controller hàng hóa
    /// </summary>
    [Route("api/v1/[controller]s")]
    public class InventoryItemController : BaseController<InventoryItem>
    {
        /// <summary>
        /// Service hàng hóa
        /// </summary>
        IInventoryItemService _inventoryItemService;
        /// <summary>
        /// Repository hàng hóa
        /// </summary>
        IInventoryItemRepository _inventoryItemRepository;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="inventoryItemService"></param>
        /// <param name="inventoryItemRepository"></param>
        public InventoryItemController(IInventoryItemService inventoryItemService, IInventoryItemRepository inventoryItemRepository):base(inventoryItemService, inventoryItemRepository)
        {
            _inventoryItemService = inventoryItemService;
            _inventoryItemRepository = inventoryItemRepository;
        }
    }
}
