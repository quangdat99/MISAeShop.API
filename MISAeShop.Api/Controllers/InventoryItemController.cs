using Microsoft.AspNetCore.Mvc;
using MISAeShop.Core.Entities;
using MISAeShop.Core.Exceptions;
using MISAeShop.Core.Interfaces.Repository;
using MISAeShop.Core.Interfaces.Service;
using MISAeShop.Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAeShop.Api.Controllers
{
    /// <summary>
    /// Controller hàng hóa
    /// </summary>
    /// CreatedBy: dqdat (20/07/2021)
    [Route("api/v1/[controller]s")]
    public class InventoryItemController : BaseController<InventoryItem>
    {
        #region Declare
        /// <summary>
        /// Service hàng hóa
        /// </summary>
        IInventoryItemService _inventoryItemService;
        /// <summary>
        /// Repository hàng hóa
        /// </summary>
        IInventoryItemRepository _inventoryItemRepository;
        #endregion

        #region Constructor
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
        #endregion

        #region Methods
        /// <summary>
        /// Lấy thông tin hàng hóa theo mã sku
        /// </summary>
        /// <param name="skuCode"></param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (20/07/2021)
        [HttpGet("GetInventoryItemBySKUCode/{skuCode}")]
        public IActionResult GetInventoryItemBySKUCode(string skuCode)
        {
            try
            {
                var res = _inventoryItemRepository.GetInventoryItemBySKUCode(skuCode);
                if (res != null)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "", null);
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, null);
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Lấy danh sách hàng hóa theo parentID
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (20/07/2021)
        [HttpGet("GetInventoryItemsByParentID/{parentID}")]
        public IActionResult GetInventoryItemsByParentID (Guid parentID)
        {
            try
            {
                var res = _inventoryItemRepository.GetInventoryItemsByParentID(parentID);
                if (res.Count() > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "", new List<InventoryItem>());
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, new List<InventoryItem>());
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Xóa hàng hóa theo parentID
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (20/07/2021)
        [HttpDelete("DeleteInventoryItemByParentID/{parentID}")]
        public IActionResult DeleteInventoryItemByParentID(Guid parentID)
        {
            try
            {
                var rowsAffect = _inventoryItemRepository.DeleteInventoryItemByParentID(parentID);
                if (rowsAffect > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.deleteDataSuccess, "", rowsAffect);
                    return Ok(actionResult);
                }
                else if(rowsAffect == 0)
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noData, "", 0);
                    return Ok(actionResult);
                }
                else 
                {
                    var actionResult = new Core.Entities.ActionResult(500, Resources.deleteDataFail, "", 0);
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
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, 0);
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Lấy toàn bộ thông tin thành phần hàng hóa của combo
        /// </summary>
        /// <param name="inventoryItemComboID"></param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (20/07/2021)
        [HttpGet("GetInventoryItemComboDetails/{inventoryItemComboID}")]
        public IActionResult GetInventoryItemComboDetails(Guid inventoryItemComboID)
        {
            try
            {
                var res = _inventoryItemRepository.GetInventoryItemComboDetails(inventoryItemComboID);
                if (res.Count() > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "", new List<InventoryItem>());
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, new List<InventoryItem>());
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Lấy thông tin hàng hóa lựa chọn làm thành phần của combo
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (20/07/2021)
        [HttpGet("GetInventoryItemSelectOptionComboByParentID/{parentID}")]
        public IActionResult GetInventoryItemSelectOptionComboByParentID(Guid parentID)
        {
            try
            {
                var res = _inventoryItemRepository.GetInventoryItemSelectOptionComboByParentID(parentID);
                if (res.Count() > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "", new List<InventoryItem>());
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, new List<InventoryItem>());
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Lấy danh sách hàng hóa làm thành phần cho combo
        /// </summary>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (20/07/2021)
        [HttpGet("GetInventoryItemsOptionCombo")]
        public IActionResult GetInventoryItemsOptionCombo()
        {
            try
            {
                var res = _inventoryItemRepository.GetInventoryItemsOptionCombo();
                if (res.Count() > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "", new List<InventoryItem>());
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, new List<InventoryItem>());
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Lấy mã mới từ bảng sinh mã tự động
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (20/07/2021)
        [HttpGet("GetNewCode")]
        public IActionResult GetNewCode(string tableName, string fieldName)
        {
            try
            {
                var newCode = _inventoryItemService.GetAutoIncreaseCode(tableName, fieldName);
                if (newCode != null)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", newCode);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "",  null);
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, null);
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Kiểm tra hàng hóa đã có phát sinh hay chưa
        /// </summary>
        /// <param name="inventoryItemID"></param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (20/07/2021)
        [HttpGet("CheckInventoryItemIncurred/{inventoryItemID}")]
        public IActionResult CheckInventoryItemIncurred(Guid inventoryItemID)
        {
            try
            {
                var isIncurred = _inventoryItemRepository.CheckInventoryItemIncurred(inventoryItemID);
                
                var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", isIncurred);
                return Ok(actionResult);
                
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, null);
                return Ok(actionResult);
            }
        }
        #endregion
    }
}
