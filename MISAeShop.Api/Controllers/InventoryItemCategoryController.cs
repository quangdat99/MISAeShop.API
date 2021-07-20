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
    /// Controller nhóm hàng hóa
    /// </summary>
    /// CreatedBy: dqdat (20/07/2021)
    [Route("api/v1/[controller]s")]
    public class InventoryItemCategoryController : BaseController<InventoryItemCategory>
    {
        /// <summary>
        /// Service nhóm hàng hóa
        /// </summary>
        IInventoryItemCategoryService _inventoryItemCategoryService;

        /// <summary>
        /// Repository nhóm hàng hóa
        /// </summary>
        IInventoryItemCategoryRepository _inventoryItemCategoryRepository;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="inventoryItemCategoryService"></param>
        /// <param name="inventoryItemCategoryRepository"></param>
        public InventoryItemCategoryController(IInventoryItemCategoryService inventoryItemCategoryService, IInventoryItemCategoryRepository inventoryItemCategoryRepository):base(inventoryItemCategoryService, inventoryItemCategoryRepository)
        {
            _inventoryItemCategoryService = inventoryItemCategoryService;
            _inventoryItemCategoryRepository = inventoryItemCategoryRepository;
        }
    }
}
