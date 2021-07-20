using Microsoft.AspNetCore.Mvc;
using MISAeShop.Core.Entities;
using MISAeShop.Core.Exceptions;
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

        [HttpDelete("DeleteItemCombo")]
        public IActionResult DeleteItemCombo(Guid childID, int componentID, Guid inventoryItemComboDetailID)
        {
            try
            {
                var rowsAffect = _inventoryItemComboDetailRepository.DeleteItemCombo(childID, componentID, inventoryItemComboDetailID);
                if (rowsAffect > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, "Xóa dữ liệu thành công", "", rowsAffect);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, "Xóa không thành công", "", 0);
                    return Ok(actionResult);
                }
            }
            catch (ValidateException exception)
            {
                var actionResult = new Core.Entities.ActionResult(400, exception.Message, "", exception.DataErr);
                return Ok(actionResult);
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, 0);
                return Ok(actionResult);
            }
        }
    }
}
