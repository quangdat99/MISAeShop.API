using Microsoft.AspNetCore.Mvc;
using MISAeShop.Core.Entities;
using MISAeShop.Core.Interfaces.Repository;
using MISAeShop.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAeShop.Api.Controllers
{
    /// <summary>
    /// Controller đơn vị tính
    /// </summary>
    [Route("api/v1/[controller]s")]
    public class UnitController : BaseController<Unit>
    {   
        /// <summary>
        /// Service đơn vị tính
        /// </summary>
        IUnitService _unitService;

        /// <summary>
        /// Repository đơn vị tính
        /// </summary>
        IUnitRepository _unitRepository;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="unitService"></param>
        /// <param name="unitRepository"></param>
        public UnitController(IUnitService unitService, IUnitRepository unitRepository):base(unitService,unitRepository)
        {
            _unitService = unitService;
            _unitRepository = unitRepository;
        }
    }
}
