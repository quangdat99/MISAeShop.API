using MISAeShop.Core.Entities;
using MISAeShop.Core.Exceptions;
using MISAeShop.Core.Interfaces.Repository;
using MISAeShop.Core.Interfaces.Service;
using MISAeShop.Core.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Services
{   
    /// <summary>
    /// Service hàng hóa
    /// </summary>
    public class InventoryItemService: BaseService<InventoryItem>, IInventoryItemService
    {
        #region DECLARE
        /// <summary>
        /// Repository hàng hóa
        /// </summary>
        IInventoryItemRepository _inventoryItemRepository;
        #endregion

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="inventoryItemRepository"></param>
        public InventoryItemService(IInventoryItemRepository inventoryItemRepository):base(inventoryItemRepository)
        {
            _inventoryItemRepository = inventoryItemRepository;
        }
        /// <summary>
        /// Phương thức dùng để cho valid của các trường hợp riêng biệt.
        /// </summary>
        /// <param name="t">Một thực thể</param>
        /// <param name="isInsert">Xác định insert hoặc update</param>
        /// CreatedBy: dqdat (13/06/2021)
        protected override bool ValidateCustom(InventoryItem inventoryItem, bool isInsert = true)
        {
            var isValid = true;

            bool isExistSKUCode = false;
            inventoryItem.SKUCode = inventoryItem.SKUCode.Trim();

            if (isInsert == true)
            {
                isExistSKUCode = _inventoryItemRepository.CheckSKUCodeExist(inventoryItem.SKUCode);
            }
            else
            {
                isExistSKUCode = _inventoryItemRepository.CheckSKUCodeExist(inventoryItem.SKUCode, inventoryItem.InventoryItemID);
            }

            if (isExistSKUCode == true)
            {
                isValid = false;
                IDictionary dictionary = new Dictionary<string, string>
                {
                    { "SKUCode", inventoryItem.SKUCode }
                };
                throw new ValidateException(string.Format(ValidateResources.MsgErrorSKUCodeExists, inventoryItem.SKUCode), dictionary);

            }


            bool isExistBarCode = false;
            inventoryItem.BarCode = inventoryItem.BarCode.Trim();

            if (isInsert == true)
            {
                isExistBarCode = _inventoryItemRepository.CheckBarCodeExist(inventoryItem.BarCode);
            }
            else
            {
                isExistBarCode = _inventoryItemRepository.CheckBarCodeExist(inventoryItem.BarCode, inventoryItem.InventoryItemID);
            }

            if (isExistBarCode == true)
            {
                isValid = false;
                IDictionary dictionary = new Dictionary<string, string>
                {
                    { "BarCode", inventoryItem.BarCode }
                };
                throw new ValidateException(string.Format(ValidateResources.MsgErrorBarCodeExists, inventoryItem.BarCode), dictionary);

            }

            return isValid;


        }
    }
}
