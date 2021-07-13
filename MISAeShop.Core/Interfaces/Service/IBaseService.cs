using MISAeShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Interfaces.Service
{
    /// <summary>
    /// Interface Service chung
    /// </summary>
    /// <typeparam name="T">Một thực thể</typeparam>
    /// CreatedBy: dqdat (12/07/2021)
    public interface IBaseService<T> where T : class
    {
        /// <summary>
        /// Lấy dữ liệu có phân trang, lọc và sắp xếp theo tiêu chí chọn
        /// </summary>
        /// <param name="PageSize">Số bản ghi một trang</param>
        /// <param name="PageNumber">Số thứ tự trang</param>
        /// <param name="WhereClause">Tiêu chí lọc</param>
        /// <param name="Sort">Tiêu chí sắp xếp</param>
        /// <returns>Danh sách bản ghi theo yêu cầu</returns>    
        /// CreatedBy: dqdat (12/07/2021)
        public IEnumerable<T> GetPaging(int PageSize, int PageNumber, List<FilterData> listFilters, ref int totalRecord);

        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="t">Thông tin đối tượng thêm mới</param>
        /// <returns>Số bản ghi thêm mới được vào database</returns>
        /// CreatedBy: dqdat (12/07/2021)
        int? Insert(T t);


        /// <summary>
        /// Sửa 
        /// </summary>
        /// <param name="t">Thông tin đối tượng cần sửa</param>
        /// <param name="id">Id của đối tượng cần sửa</param>
        /// <returns>Số bản ghi thêm mới được vào database</returns>
        /// CreatedBy: dqdat (12/07/2021)
        int? Update(T t, Guid id);
    }
}
