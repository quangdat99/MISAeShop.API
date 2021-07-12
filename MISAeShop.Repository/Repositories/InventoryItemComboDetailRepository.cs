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
    /// Repository Thành phần hàng hóa của combo
    /// </summary>
    public class InventoryItemComboDetailRepository:BaseRepository<InventoryItemComboDetail>, IInventoryItemComboDetailRepository
    {
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="configuration">Config của project</param>
        public InventoryItemComboDetailRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
