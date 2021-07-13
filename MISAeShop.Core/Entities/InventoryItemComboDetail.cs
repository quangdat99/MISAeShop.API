using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Entities
{
    /// <summary>
    /// Thông tin thành phần hàng hóa loại combo
    /// </summary>
    public class InventoryItemComboDetail
    {
        /// <summary>
        /// ID của hàng hóa loại combo
        /// </summary>
        public Guid InventoryItemComboDetailID { get; set; }
        /// <summary>
        /// ID của hàng hóa thành phần của combo
        /// </summary>
        public Guid Child { get; set; }
        /// <summary>
        /// Sử dụng: 1-có, 2-không
        /// </summary>
        public int? IsSelected { get; set; } = 1;
        /// <summary>
        /// Số lượng
        /// </summary>
        public int? Quantity { get; set; }
    }
}
