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
    /// Controller thành phần hàng hóa của combo
    /// </summary>
    /// CreatedBy: dqdat (20/07/2021)
    [Route("api/v1/[controller]s")]
    public class InventoryItemComboDetailController : BaseController<InventoryItemComboDetail>
    {
        #region Declare
        /// <summary>
        /// Service thành phần hàng hóa của combo
        /// </summary>
        IInventoryItemComboDetailService _inventoryItemComboDetailService;
        /// <summary>
        /// Repository thành phần hàng hóa của combo
        /// </summary>
        IInventoryItemComboDetailRepository _inventoryItemComboDetailRepository;
        #endregion

        #region Constructor
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
        #endregion

        #region Methods
        /// <summary>
        /// Xóa thông tin hàng hóa thành phần của combo
        /// </summary>
        /// <param name="childID"></param>
        /// <param name="componentID"></param>
        /// <param name="inventoryItemComboDetailID"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        [HttpDelete("DeleteItemCombo")]
        public IActionResult DeleteItemCombo(Guid childID, int componentID, Guid inventoryItemComboDetailID)
        {
            try
            {
                var rowsAffect = _inventoryItemComboDetailRepository.DeleteItemCombo(childID, componentID, inventoryItemComboDetailID);
                if (rowsAffect > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200,  Resources.deleteDataSuccess, "", rowsAffect);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.deleteDataFail, "", 0);
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
        #endregion
    }
}
