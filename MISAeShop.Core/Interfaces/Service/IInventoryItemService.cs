using MISAeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Interfaces.Service
{
    /// <summary>
    /// Interface service Hàng hóa
    /// </summary>
    /// CreatedBy: dqdat (20/07/2021)
    public interface IInventoryItemService: IBaseService<InventoryItem>
    {
        /// <summary>
        /// Lấy mã tự động tăng từ hệ thống
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        public string GetAutoIncreaseCode(string tableName, string fieldName);
    }
}
