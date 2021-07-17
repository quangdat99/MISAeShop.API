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

        [HttpGet("GetInventoryItemBySKUCode/{skuCode}")]
        public IActionResult GetInventoryItemBySKUCode(string skuCode)
        {
            try
            {
                var res = _inventoryItemRepository.GetInventoryItemBySKUCode(skuCode);
                if (res != null)
                {
                    var actionResult = new Core.Entities.ActionResult(200, "Lấy dữ liệu thành công", "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, "Không có dữ liệu trả về", "", null);
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, null);
                return Ok(actionResult);
            }
        }

        [HttpGet("GetInventoryItemsByParentID/{parentID}")]
        public IActionResult GetInventoryItemsByParentID (Guid parentID)
        {
            try
            {
                var res = _inventoryItemRepository.GetInventoryItemsByParentID(parentID);
                if (res.Count() > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, "Lấy dữ liệu thành công", "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, "Không có dữ liệu trả về", "", new List<InventoryItem>());
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, new List<InventoryItem>());
                return Ok(actionResult);
            }
        }
    }
}
