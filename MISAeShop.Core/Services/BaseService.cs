using MISAeShop.Core.Interfaces.Repository;
using MISAeShop.Core.Interfaces.Service;
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
        /// <summary>
        /// Thêm mới một thực thể
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (12/07/2021)
        public int? Insert(T t)
        {
            // Validate dữ liệu:
            var isValid = true;
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
            var isValid = true;
            if (isValid == true)
            {
                return _baseRepository.Update(t, id);
            }
            else
            {
                return null;
            }
        }

        #endregion
    }

}
