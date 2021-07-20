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
    /// CreatedBy: dqdat (20/07/2021)
    public class InventoryItemService: BaseService<InventoryItem>, IInventoryItemService
    {
        #region DECLARE
        /// <summary>
        /// Repository hàng hóa
        /// </summary>
        IInventoryItemRepository _inventoryItemRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="inventoryItemRepository"></param>
        public InventoryItemService(IInventoryItemRepository inventoryItemRepository):base(inventoryItemRepository)
        {
            _inventoryItemRepository = inventoryItemRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Phương thức dùng để cho valid của các trường hợp riêng biệt.
        /// </summary>
        /// <param name="t">Một thực thể</param>
        /// <param name="isInsert">Xác định insert hoặc update</param>
        /// CreatedBy: dqdat (20/07/2021)
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

        /// <summary>
        /// Thêm mới hàng hóa
        /// </summary>
        /// <param name="inventoryItem"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        public override int? Insert(InventoryItem inventoryItem)
        {
            if (string.IsNullOrEmpty(inventoryItem.SKUCode) )
            {
                inventoryItem.SKUCode = GetAutoIncreaseCode("InventoryItem", "SKUCode");
            }
            if (string.IsNullOrEmpty(inventoryItem.BarCode))
            {
                inventoryItem.BarCode = GetAutoIncreaseCode("InventoryItem", "BarCode");
            }
            var res = base.Insert(inventoryItem);
            return res;
        }

        /// <summary>
        /// Sửa thông tin hàng hóa
        /// </summary>
        /// <param name="inventoryItem"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CreatedBy: dqdat (20/07/2021)
        public override int? Update(InventoryItem inventoryItem, Guid id)
        {
            if (string.IsNullOrEmpty(inventoryItem.SKUCode))
            {
                inventoryItem.SKUCode = GetAutoIncreaseCode("InventoryItem", "SKUCode");
            }
            if (string.IsNullOrEmpty(inventoryItem.BarCode))
            {
                inventoryItem.BarCode = GetAutoIncreaseCode("InventoryItem", "BarCode");
            }
            var res = base.Update(inventoryItem, id);
            return res;
        }


        public string GetAutoIncreaseCode(string tableName, string fieldName)
        {
            var newCode = "";
            var isDuplicate = true;
            do
            {
                // Lấy thông tin mã tự động tăng từ hệ thống
                var autoIncreaseCode = _inventoryItemRepository.GetAutoIncreaseCode(tableName, fieldName) as AutoIncreaseCode;

                if (fieldName == "SKUCode")
                {
                    // Lấy mã SKU mới
                    newCode = autoIncreaseCode.Prefix + (autoIncreaseCode.Value)?.ToString("D"+(autoIncreaseCode.Length).ToString());
                    isDuplicate = _inventoryItemRepository.CheckSKUCodeExist(newCode);
                    if (isDuplicate)
                    {
                        _inventoryItemRepository.updateAutoIncreaseCode(tableName, fieldName, autoIncreaseCode.Value + 1);
                    }
                }
                else if (fieldName == "BarCode")
                {
                    // Lấy mã vạch mới
                    newCode = autoIncreaseCode.Prefix + (autoIncreaseCode.Value)?.ToString("D" + (autoIncreaseCode.Length).ToString());
                    isDuplicate = _inventoryItemRepository.CheckBarCodeExist(newCode);
                    if (isDuplicate)
                    {
                        _inventoryItemRepository.updateAutoIncreaseCode(tableName, fieldName, autoIncreaseCode.Value + 1);
                    }
                }
                
            } while (isDuplicate);

            return newCode;
        }
        #endregion
    }
}
