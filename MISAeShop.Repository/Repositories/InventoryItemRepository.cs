﻿using Dapper;
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
    /// Repository hàng hóa
    /// </summary>
    public class InventoryItemRepository: BaseRepository<InventoryItem>, IInventoryItemRepository
    {
        #region Declare
        DynamicParameters Parameters;
        #endregion
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="configuration">Config của project</param>
        public InventoryItemRepository(IConfiguration configuration) : base(configuration)
        {
            Parameters = new DynamicParameters();

        }

        public bool CheckBarCodeExist(string barCode, Guid? inventoryItemID = null)
        {
            Parameters.Add("@m_BarCode", barCode);
            Parameters.Add("@m_InventoryItemID", inventoryItemID);
            var isExist = DbConnection.ExecuteScalar<bool>("Proc_CheckBarCodeExist", param: Parameters, commandType: CommandType.StoredProcedure);
            return isExist;
        }

        public bool CheckSKUCodeExist(string skuCode, Guid? inventoryItemID = null)
        {
            Parameters.Add("@m_SKUCode", skuCode);
            Parameters.Add("@m_InventoryItemID", inventoryItemID);
            var isExist = DbConnection.ExecuteScalar<bool>("Proc_CheckSKUCodeExist", param: Parameters, commandType: CommandType.StoredProcedure);
            return isExist;
        }

        public int DeleteInventoryItemByParentID(Guid parentID)
        {
            Parameters.Add($"@m_ParentID", parentID);
            var rowAffect = DbConnection.Execute($"Proc_DeleteInventoryItemByParentID", param: Parameters, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }

        public InventoryItem GetInventoryItemBySKUCode(string skuCode)
        {
            Parameters.Add("@m_SKUCode", skuCode);
            var inventoryItem = DbConnection.QueryFirstOrDefault<InventoryItem>("Proc_GetInventoryItemBySKUCode", param: Parameters, commandType: CommandType.StoredProcedure);

            return inventoryItem;
        }

        public IEnumerable<InventoryItem> GetInventoryItemComboDetails(Guid inventoryItemComboID)
        {
            Parameters.Add("@m_InventoryItemComboDetailID", inventoryItemComboID);
            var inventoryItems = DbConnection.Query<InventoryItem>("Proc_GetInventoryItemComboDetails", param: Parameters, commandType: CommandType.StoredProcedure);

            return inventoryItems;
        }

        public IEnumerable<InventoryItem> GetInventoryItemsByParentID(Guid parentID)
        {
            Parameters.Add("@m_ParentID", parentID);
            var inventoryItems = DbConnection.Query<InventoryItem>("Proc_GetInventoryItemsByParentID", param: Parameters, commandType: CommandType.StoredProcedure);

            return inventoryItems;
        }

        public IEnumerable<InventoryItem> GetInventoryItemSelectOptionComboByParentID(Guid parentID)
        {
            Parameters.Add("@m_ParentID", parentID);
            var inventoryItems = DbConnection.Query<InventoryItem>("Proc_GetInventoryItemSelectOptionComboByParentID", param: Parameters, commandType: CommandType.StoredProcedure);

            return inventoryItems;
        }

        public IEnumerable<InventoryItem> GetInventoryItemsOptionCombo()
        {
            var inventoryItems = DbConnection.Query<InventoryItem>("Proc_GetInventoryItemsOptionCombo", commandType: CommandType.StoredProcedure);

            return inventoryItems;
        }
    }
}
