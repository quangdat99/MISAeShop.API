using MISAeShop.Core.Entities;
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
    /// Service đơn vị tính
    /// </summary>
    public class UnitService :BaseService<Unit>, IUnitService
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="unitRepository"></param>
        public UnitService(IUnitRepository unitRepository ):base(unitRepository)
        {

        }
    }
}
