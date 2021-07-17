using MISAeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface Repository Hàng hóa
    /// </summary>
    public interface IInventoryItemRepository: IBaseRepository<InventoryItem>
    {
        /// <summary>
        /// Lấy thông tin hàng hóa bằng mã skuCode
        /// </summary>
        /// <param name="skuCode"></param>
        /// <returns></returns>
        public InventoryItem GetInventoryItemBySKUCode(string skuCode);

        /// <summary>
        /// Lấy toàn bộ thông tin hàng hóa theo parentID
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public IEnumerable<InventoryItem> GetInventoryItemsByParentID(Guid parentID);
    }
}
