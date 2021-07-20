using MISAeShop.Core.Attributes;
using MISAeShop.Core.Entities;
using MISAeShop.Core.Exceptions;
using MISAeShop.Core.Interfaces.Repository;
using MISAeShop.Core.Interfaces.Service;
using MISAeShop.Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Services
{
    /// <summary>
    /// Base service
    /// </summary>
    /// <typeparam name="T">Một thực thể</typeparam>
    /// CreatedBy: dqdat (12/07/2021)
    public class BaseService<T> : IBaseService<T> where T : class
    {
        #region DECLARE
        /// <summary>
        /// Base repository
        /// </summary>
        IBaseRepository<T> _baseRepository;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="baseRepository"> Base repository</param>
        /// CreatedBy: dqdat (12/07/2021)
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region METHODS
        public IEnumerable<T> GetPaging(FilterPagingData filterPagingData, ref int TotalRecord)
        {
            var WhereClause = new StringBuilder();
            var Sort = "";

            // Kiểm tra Sắp xếp
            if (filterPagingData.SortProperty == null || filterPagingData.SortProperty =="")
            {
                Sort += "CreatedDate Desc";
            }
            else
            {
                Sort += filterPagingData.SortProperty + " " + filterPagingData.SortType;

            }
            // Kiểm tra nếu ko có yêu cầu lọc thì lấy hết dữ liệu
            if (filterPagingData.DataFilter.Count() == 0)
            {
                WhereClause.Append("1=1");
            }
            else
            {
                var indexOfFilterData = 1;
                foreach (var filterData in filterPagingData.DataFilter)
                {

                    if (filterData.FilterValue is not null)
                    {
                        //thực hiện nối mệnh đề
                        if ( indexOfFilterData > 1)
                        {
                            WhereClause.Append(" And ");
                        }

                        WhereClause.Append("(");
                        WhereClause.Append(filterData.FilterProperty);

                        // kiểm tra nếu giá trị lọc mà rỗng thì sẽ lấy tất cả dữ liệu
                        if (filterData.FilterValue.ToString() == "" || filterData.FilterValue.ToString() == "0")
                        {
                            WhereClause.Append(" LIKE");
                            WhereClause.Append(" CONCAT('%', '");
                            WhereClause.Append("");
                            WhereClause.Append("','%')");
                            WhereClause.Append("Or ");
                            WhereClause.Append(filterData.FilterProperty);
                            WhereClause.Append(" Is Null )");
                        }
                        else
                        {
                            // build mệnh đề cho câu lệnh where
                            BuildWhereClause(filterData, WhereClause);
                        }

                    }

                    indexOfFilterData++;
                }
            }
            WhereClause.Append(" And ParentID IS NULL ");
            var entities = _baseRepository.GetPaging(filterPagingData.PageSize, filterPagingData.PageNumber, WhereClause.ToString(), Sort, ref TotalRecord);
            return entities;
        }

        /// <summary>
        /// Thêm mới một thực thể
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (12/07/2021)
        public int? Insert(T t)
        {
            // Validate dữ liệu:
            var isValid = ValidateObject(t);
            if (isValid == true)
            {
                return _baseRepository.Insert(t);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Cập nhật một thực thể
        /// </summary>
        /// <param name="t">thông tin đối tượng</param>
        /// <param name="id">id của đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: dqdat (12/07/2021)
        public int? Update(T t, Guid id)
        {
            //t.EntityState = Enum.EntityState.Update;
            // Validate dữ liệu:
            var isValid = ValidateObject(t, false);
            if (isValid == true)
            {
                return _baseRepository.Update(t, id);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Phương thức valid dữ liệu
        /// </summary>
        /// <param name="t">Thông tin của thực thể.</param>
        /// CreatedBy: dqdat (12/06/2021)
        private bool ValidateObject(T t, bool isInsert = true)
        {
            var isValid = true;

            // Check các thông tin bắt buộc nhập:
            // - Kiểu tra các property có attribute là PropertyRequired
            // -- Lấy ra các property có attribute là PropertyRequired
            // -- Kiểm tra value

            // lấy ra tất cả các property của class.
            var properties = t.GetType().GetProperties();

            foreach (var prop in properties)
            {
                // Lấy kiểu.
                var propType = prop.PropertyType;

                // Lấy giá trị.
                var propValue = prop.GetValue(t);

                // Lấy tên.
                var propName = prop.Name;

                var propertyRequireds = prop.GetCustomAttributes(typeof(PropertyRequired), true);

                // Check các thông tin không được phép trống:
                if (propertyRequireds.Length > 0)
                {
                    var propertyRequired = propertyRequireds[0] as PropertyRequired;
                    if (propType == typeof(string) && (propValue == null || propValue.ToString() == string.Empty))
                    {
                        isValid = false;
                        throw new ValidateException(string.Format(ValidateResources.NotEmpty, propertyRequired._msgError), null);
                    }
                    if (propType == typeof(Guid?) && (propValue == null || propValue.ToString() == string.Empty))
                    {
                        isValid = false;
                        throw new ValidateException(string.Format(ValidateResources.NotEmpty, propertyRequired._msgError), null);
                    }
                }


            }


            // Validate đặc thù cho từng đối tượng:
            if (isValid == true)
            {
                isValid = ValidateCustom(t, isInsert);
            }
            return isValid;
        }

        /// <summary>
        /// Phương thức dùng để cho valid của các trường hợp riêng biệt.
        /// </summary>
        /// <param name="t">Một thực thể</param>
        /// <returns></returns>
        /// CreatedBy: dqdat (12/06/2021)
        protected virtual bool ValidateCustom(T t, bool isInsert)
        {
            return true;
        }

        /// <summary>
        /// Build từng mệnh đề cho câu lệnh Where
        /// </summary>
        /// <param name="filterData">trường thông tin cần lọc</param>
        /// <param name="WhereClause"> câu lệnh where</param>
        /// CreatedBy: dqdat (12/07/2021)
        private void BuildWhereClause(FilterData filterData, StringBuilder WhereClause)
        {
            switch (filterData.FilterType)
            {
                case 1:
                    WhereClause.Append(" LIKE");
                    WhereClause.Append(" CONCAT('%', '");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("','%'))");
                    break;
                case 2:
                    WhereClause.Append(" LIKE");
                    WhereClause.Append(" CONCAT('");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("','%'))");
                    break;
                case 3:
                    WhereClause.Append(" LIKE");
                    WhereClause.Append(" CONCAT('%','");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("'))");
                    break;
                case 4:
                    WhereClause.Append(" LIKE");
                    WhereClause.Append(" CONCAT( '");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("'))");
                    break;
                case 5:
                    WhereClause.Append(" NOT LIKE");
                    WhereClause.Append(" CONCAT('%', '");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append("','%'))");
                    break;
                case 6:
                    WhereClause.Append(" <= ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
                case 7:
                    WhereClause.Append(" < ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
                case 8:
                    WhereClause.Append(" = ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
                case 9:
                    WhereClause.Append(" >= ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
                case 10:
                    WhereClause.Append(" > ");
                    WhereClause.Append(filterData.FilterValue);
                    WhereClause.Append(")");
                    break;
            }
        }

        #endregion
    }

}
