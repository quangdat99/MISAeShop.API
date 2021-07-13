using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Entities
{
    /// <summary>
    /// Thông tin lọc cho một trường
    /// </summary>
    public class FilterData
    {
        /// <summary>
        /// Tên trường được lọc dữ liệu
        /// </summary>
        public string FilterProperty { get; set; }
        /// <summary>
        /// Giá trị cần được lọc dữ liệu
        /// </summary>
        public dynamic FilterValue { get; set; }
        /// <summary>
        /// Kiểu lọc dữ liệu
        /// </summary>
        public int FilterType { get; set; }
        /// <summary>
        /// Xác nhận có được sort hay không
        /// </summary>
        public bool IsSort { get; set; }
        /// <summary>
        /// Xác định kiểu sort
        /// </summary>
        public string SortType { get; set; }
    }
}
