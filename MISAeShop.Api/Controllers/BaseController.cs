using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISAeShop.Core.Entities;
using MISAeShop.Core.Exceptions;
using MISAeShop.Core.Interfaces.Repository;
using MISAeShop.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAeShop.Api.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    /// <typeparam name="T">Một thực thể</typeparam>
    /// CreatedBy: dqdat (12/07/2021)
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        #region DECLARE
        /// <summary>
        /// Base service
        /// </summary>
        IBaseService<T> _baseService;

        /// <summary>
        /// Base Repository
        /// </summary>
        IBaseRepository<T> _baseRepository;
        #endregion

        #region CONSTRUCTOR
        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="baseService"></param>
        public BaseController(IBaseService<T> baseService, IBaseRepository<T> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Lấy tất cả thực thể T
        /// </summary>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/07/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var res = _baseRepository.GetAll();
                if (res.Count() > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, "Lấy dữ liệu thành công", "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, "Không có dữ liệu trả về", "", new List<T>());
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, new List<T>());
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Lấy thông tin thực thể t
        /// </summary>
        /// <param name="id">id thực thể</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/07/2021)
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
           
            try
            {
                var res = _baseRepository.GetById(id);
                if (res != null)
                {
                    var actionResult = new Core.Entities.ActionResult(200, "Lấy dữ liệu thành công", "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, "Không có dữ liệu trả về", "", null);
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, null);
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Insert một thực thể t
        /// </summary>
        /// <param name="t">Thông tin thực thể t</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/07/2021)
        [HttpPost]
        public IActionResult Insert(T t)
        {
            try
            {
                var rowsAffect = _baseService.Insert(t);
                if (rowsAffect > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, "Thêm dữ liệu thành công", "", rowsAffect);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, "Thêm mới không thành công", "", 0);
                    return Ok(actionResult);
                }
            }
            catch (ValidateException exception)
            {
                var actionResult = new Core.Entities.ActionResult(400, exception.Message, "", exception.DataErr);
                return Ok(actionResult);

            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, 0);
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Update một thực thể t
        /// </summary>
        /// <param name="t">Thông tin thực thể t</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/07/2021)
        [HttpPut("{id}")]
        public IActionResult Update(T t, Guid id)
        {
            try
            {
                var rowsAffect = _baseService.Update(t, id);
                if (rowsAffect > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, "Sửa dữ liệu thành công", "", rowsAffect);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, "Sửa không thành công", "", 0);
                    return Ok(actionResult);
                }
            }
            catch (ValidateException exception)
            {
                var actionResult = new Core.Entities.ActionResult(400, exception.Message, "", 0);
                return Ok(actionResult);
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, 0);
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Delete một thực thể t
        /// </summary>
        /// <param name="id">id thực thể</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dqdat (12/07/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var rowsAffect = _baseRepository.Delete(id);
                if (rowsAffect > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, "Xóa dữ liệu thành công", "", rowsAffect);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, "Xóa không thành công", "", 0);
                    return Ok(actionResult);
                }
            }
            catch (ValidateException exception)
            {
                var actionResult = new Core.Entities.ActionResult(400, exception.Message, "", exception.DataErr);
                return Ok(actionResult);
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, 0);
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo phân trang
        /// </summary>
        /// <param name="PageNumber">vị trí trang</param>
        /// <param name="PageSize">kích cỡ trang</param>
        /// <returns>Dữ liệu trả về có phân trang
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// </returns>
        /// created by ndluc(12/06/2021)
        [HttpPost("GetPaging")]
        public IActionResult GetPaging(int PageSize, int PageNumber, List<FilterData> listFilters)
        {
            try
            {
                var totalRecord = 0;
                var res = _baseService.GetPaging(PageSize, PageNumber, listFilters, ref totalRecord);
                if (res.Count() == 0)
                {
                    var actionResult = new Core.Entities.ActionResult(204, "Không có dữ liệu trả về", "", new List<T>());
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(200, "Lấy dữ liệu thành công", "", res, totalRecord);
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp", exception.Message, new List<T>());
                return Ok(actionResult);
            }
            #endregion
        }
    }
}
