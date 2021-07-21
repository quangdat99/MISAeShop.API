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
    /// CreatedBy: dqdat (20/07/2021)
    public interface IInventoryItemRepository: IBaseRepository<InventoryItem>
    {
        /// <summary>
        /// Lấy thông tin hàng hóa bằng mã skuCode
        /// </summary>
        /// <param name="skuCode"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        InventoryItem GetInventoryItemBySKUCode(string skuCode);

        /// <summary>
        /// Lấy toàn bộ thông tin hàng hóa theo parentID
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        IEnumerable<InventoryItem> GetInventoryItemsByParentID(Guid parentID);

        /// <summary>
        /// Xóa thông tin hàng hóa bằng theo parentID
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        int DeleteInventoryItemByParentID(Guid parentID);

        /// <summary>
        /// Lấy toàn bộ thông tin thành phần hàng hóa của combo
        /// </summary>
        /// <param name="inventoryItemComboID"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        IEnumerable<InventoryItem> GetInventoryItemComboDetails(Guid inventoryItemComboID);

        /// <summary>
        /// Lấy danh sách hàng hóa làm thành phần cho combo
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        IEnumerable<InventoryItem> GetInventoryItemsOptionCombo();

        /// <summary>
        /// Lấy thông tin hàng hóa lựa chọn làm thành phần của combo
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        IEnumerable<InventoryItem> GetInventoryItemSelectOptionComboByParentID(Guid parentID);

        /// <summary>
        /// Kiểm tra trùng mã sku
        /// </summary>
        /// <param name="skuCode"></param>
        /// <param name="inventoryItemID"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        public bool CheckSKUCodeExist(string skuCode, Guid? inventoryItemID = null);

        /// <summary>
        /// Kiểm tra trùng mã vạch
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="inventoryItemID"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        public bool CheckBarCodeExist(string barCode, Guid? inventoryItemID = null);

        /// <summary>
        /// Kiểm tra hàng hóa đã có phát sinh hay chưa
        /// </summary>
        /// <param name="inventoryItemID"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        public bool CheckInventoryItemIncurred(Guid inventoryItemID);

        /// <summary>
        /// Lấy mã tự động tăng
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        public AutoIncreaseCode GetAutoIncreaseCode(string tableName, string fieldName);

        /// <summary>
        /// Cập nhật lại giá trị mã tự động tăng
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// CreatedBy: dqdat (20/07/2021)
        public void updateAutoIncreaseCode(string tableName, string fieldName, int? value);
    }
}
