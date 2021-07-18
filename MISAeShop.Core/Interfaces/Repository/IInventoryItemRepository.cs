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
         InventoryItem GetInventoryItemBySKUCode(string skuCode);

        /// <summary>
        /// Lấy toàn bộ thông tin hàng hóa theo parentID
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
         IEnumerable<InventoryItem> GetInventoryItemsByParentID(Guid parentID);

        /// <summary>
        /// Xóa thông tin hàng hóa bằng theo parentID
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        int DeleteInventoryItemByParentID(Guid parentID);

        /// <summary>
        /// Lấy toàn bộ thông tin thành phần hàng hóa của combo
        /// </summary>
        /// <param name="inventoryItemComboID"></param>
        /// <returns></returns>
        IEnumerable<InventoryItem> GetInventoryItemComboDetails(Guid inventoryItemComboID);

        /// <summary>
        /// Lấy danh sách hàng hóa làm thành phần cho combo
        /// </summary>
        /// <returns></returns>
        IEnumerable<InventoryItem> GetInventoryItemsOptionCombo();

        /// <summary>
        /// Lấy thông tin hàng hóa lựa chọn làm thành phần của combo
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        IEnumerable<InventoryItem> GetInventoryItemSelectOptionComboByParentID(Guid parentID);
    }
}
