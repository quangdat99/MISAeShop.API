using Microsoft.Extensions.Configuration;
using MISAeShop.Core.Entities;
using MISAeShop.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Repository.Repositories
{
    /// <summary>
    /// Repository đơn vị tính
    /// </summary>
    public class UnitRepository : BaseRepository<Unit>, IUnitRepository
    {/// <summary>
     /// Phương thức khởi tạo
     /// </summary>
     /// <param name="configuration">Config của project</param>
        public UnitRepository(IConfiguration configuration): base(configuration)
        {

        }
    }
}
