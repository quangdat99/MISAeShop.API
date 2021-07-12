using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Entities
{
    /// <summary>
    /// Thông tin đơn vị tính
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// ID đơn vị tính
        /// </summary>
        public Guid UnitID { get; set; }
        /// <summary>
        /// Tên đơn vị tính
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// Mô tả đơn vị tính
        /// </summary>
        public string Desciption { get; set; }
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
