using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Entities
{
    /// <summary>
    /// Thông tin nhóm hàng hóa
    /// </summary>
    public class InventoryItemCategory
    {
        /// <summary>
        /// ID nhóm hàng hóa
        /// </summary>
        public Guid InventoryItemCategoryID { get; set; }
        /// <summary>
        /// Mã nhóm hàng hóa
        /// </summary>
        public string InventoryItemCategoryCode { get; set; }
        /// <summary>
        /// Tên nhóm hàng hóa
        /// </summary>
        public string InventoryItemCategoryName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Trạng thái kinh doanh: 1-đang kinh doanh, 2-ngừng kinh doanh
        /// </summary>
        public int? Status { get; set; } = 1;
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
