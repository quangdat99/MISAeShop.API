using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISAeShop.Core.Entities
{
    /// <summary>
    /// Thông tin kết quả trả về cho client
    /// </summary>
    public class ActionResult
    {
        /// <summary>
        /// Trạng thái kết quả trả về
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Thông báo cho Client
        /// </summary>
        public string UserMessage { get; set; }

        /// <summary>
        /// Thông báo dành cho Lập trình viên
        /// </summary>
        public string DevMessage { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int TotalRecord { get; set; }

        public ActionResult(int statusCode, string userMessage, string devMessage, dynamic data)
        {
            StatusCode = statusCode;
            UserMessage = userMessage;
            DevMessage = devMessage;
            Data = data;
        }

        public ActionResult(int statusCode, string userMessage, string devMessage, dynamic data, int totalRecord)
        {
            StatusCode = statusCode;
            UserMessage = userMessage;
            DevMessage = devMessage;
            TotalRecord = totalRecord;
            Data = data;
        }
    }
}
