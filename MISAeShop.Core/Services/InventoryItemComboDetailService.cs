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
    /// Service thành phần hàng hóa của combo
    /// </summary>
    /// CreatedBy: dqdat (20/07/2021)
    public class InventoryItemComboDetailService: BaseService<InventoryItemComboDetail>, IInventoryItemComboDetailService
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="inventoryItemComboDetailRepository"></param>
        public InventoryItemComboDetailService(IInventoryItemComboDetailRepository inventoryItemComboDetailRepository):base(inventoryItemComboDetailRepository)
        {

        }
    }
}
