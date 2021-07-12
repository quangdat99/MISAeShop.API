using MISAeShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Entities
{
    /// <summary>
    /// Thông tin hàng hóa
    /// </summary>
    public class InventoryItem
    {
        /// <summary>
        /// ID hàng hóa
        /// </summary>
        public Guid InventoryItemID { get; set; }
        /// <summary>
        /// ID nhóm hàng hóa
        /// </summary>
        public Guid? InventoryItemCategoryID { get; set; }
        /// <summary>
        /// ID đươn vị tính
        /// </summary>
        public Guid? UnitID { get; set; }
        /// <summary>
        /// ID mẫu hàng hóa
        /// </summary>
        public Guid? ParentID { get; set; }
        /// <summary>
        /// Kiểu hàng hóa:
        /// </summary>
        public InventoryItemType? InventoryItemType { get; set; }
        /// <summary>
        /// Tên hàng hóa
        /// </summary>
        public string InventoryItemName { get; set; }
        /// <summary>
        /// Mã SKU
        /// </summary>
        public string SKUCode { get; set; }
        /// <summary>
        /// Mã vạch
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// Giá bán
        /// </summary>
        public int? CostPrice { get; set; }
        /// <summary>
        /// Giá mua
        /// </summary>
        public int? BuyPrice { get; set; }
        /// <summary>
        /// Giá trị tồn kho ban đầu
        /// </summary>
        public int? FirstStock { get; set; }
        /// <summary>
        /// Định mức tồn kho tối thiểu
        /// </summary>
        public int? MinimumStock { get; set; }
        /// <summary>
        /// Định mức tồn kho tối đa
        /// </summary>
        public int? MaximumStock { get; set; }
        /// <summary>
        /// Vị trí lưu trữ trong kho
        /// </summary>
        public string StockLocation { get; set; }
        /// <summary>
        /// Vị trí trưng bày
        /// </summary>
        public string ShowLocation { get; set; }
        /// <summary>
        /// Hiển thị trên màn hình bán hàng: 1-có, 2-không
        /// </summary>
        public int? ShowInMenu { get; set; }
        /// <summary>
        /// Màu sắc hàng hóa
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Kích cỡ hàng hóa
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// Trọng lượng hàng hóa
        /// </summary>
        public int? Weight { get; set; }
        /// <summary>
        /// Chiều dài gói hàng
        /// </summary>
        public int? Length { get; set; }
        /// <summary>
        /// Chiều rộng gói hàng
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// Chiều cao gói hàng
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// Mô tả mặt hàng
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Trạng thái kinh doanh: 1-đang kinh doanh, 2-ngừng kinh doanh
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// ID của ảnh
        /// </summary>
        public Guid? PictureID { get; set; }
        /// <summary>
        /// Quản lý theo
        /// </summary>
        public int? ManageType { get; set; }
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
