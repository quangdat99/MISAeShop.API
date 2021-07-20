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
    /// Service nhóm hàng hóa
    /// </summary>
    /// CreatedBy: dqdat (20/07/2021)
    public class InventoryItemCategoryService: BaseService<InventoryItemCategory>, IInventoryItemCategoryService
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="inventoryItemCategoryRepository"></param>
        public InventoryItemCategoryService(IInventoryItemCategoryRepository inventoryItemCategoryRepository):base(inventoryItemCategoryRepository)
        {

        }
    }
}
