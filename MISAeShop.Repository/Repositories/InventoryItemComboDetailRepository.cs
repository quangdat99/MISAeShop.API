using Dapper;
using Microsoft.Extensions.Configuration;
using MISAeShop.Core.Entities;
using MISAeShop.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
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
        #region Declare
        DynamicParameters Parameters;
        #endregion
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="configuration">Config của project</param>
        public InventoryItemComboDetailRepository(IConfiguration configuration) : base(configuration)
        {
            Parameters = new DynamicParameters();
        }


        public int DeleteItemCombo(Guid childID, int componentID, Guid inventoryItemComboDetailID)
        {
            Parameters.Add($"@m_ChildID", childID);
            Parameters.Add($"@m_ComponentID", componentID);
            Parameters.Add($"@m_InventoryItemComboDetailID", inventoryItemComboDetailID);
            var rowAffect = DbConnection.Execute($"Proc_DeleteItemCombo", param: Parameters, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }
    }
}
