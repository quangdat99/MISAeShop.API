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
    /// Controller thành phần hàng hóa của combo
    /// </summary>
    [Route("api/v1/[controller]s")]
    public class InventoryItemComboDetailController : BaseController<InventoryItemComboDetail>
    {
        /// <summary>
        /// Service thành phần hàng hóa của combo
        /// </summary>
        IInventoryItemComboDetailService _inventoryItemComboDetailService;
        /// <summary>
        /// Repository thành phần hàng hóa của combo
        /// </summary>
        IInventoryItemComboDetailRepository _inventoryItemComboDetailRepository;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="inventoryItemComboDetailService"></param>
        /// <param name="inventoryItemComboDetailRepository"></param>
        public InventoryItemComboDetailController(IInventoryItemComboDetailService inventoryItemComboDetailService, IInventoryItemComboDetailRepository inventoryItemComboDetailRepository):base(inventoryItemComboDetailService, inventoryItemComboDetailRepository)
        {
            _inventoryItemComboDetailService = inventoryItemComboDetailService;
            _inventoryItemComboDetailRepository = inventoryItemComboDetailRepository;
        }
    }
}
