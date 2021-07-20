using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Entities
{
    /// <summary>
    /// Mã tự động tăng
    /// </summary>
    public class AutoIncreaseCode
    {
        /// <summary>
        /// Tên bảng
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Tên trường
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Tiền tố
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Giá trị
        /// </summary>
        public int? Value { get; set; }

        /// <summary>
        /// Độ dài giá trị
        /// </summary>
        public int? Length { get; set; }
    }
}
