using MISAeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface Repository Thành phần hàng hóa của combo
    /// </summary>
    public interface IInventoryItemComboDetailRepository : IBaseRepository<InventoryItemComboDetail>
    {
        /// <summary>
        /// Xóa một hàng hóa thành phần của combo đối tượng.
        /// </summary>
        /// <param name="childID"></param>
        /// <param name="componentID"></param>
        /// <param name="inventoryItemComboDetailID"></param>
        /// <returns></returns>
        int DeleteItemCombo(Guid childID, int componentID, Guid inventoryItemComboDetailID);
    }
}
