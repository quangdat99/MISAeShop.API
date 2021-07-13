using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Entities
{
    /// <summary>
    /// Dữ liệu tìm kiếm, phân trang
    /// </summary>
    public class FilterPagingData
    {
        /// <summary>
        /// Chỉ số trang
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Kích thước trang
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Tên property để sắp xếp
        /// </summary>
        public string SortProperty { get; set; }
        /// <summary>
        /// Kiểu sắp xếp
        /// </summary>
        public string SortType { get; set; }

        public List<FilterData> DataFilter { get; set; } = new List<FilterData>();
    }
}
