using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymAPI.Interface;
using GymAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        #region Fields

        private readonly IPeriodMaster _periodMaster;
        #endregion

        #region Constructor
        public PeriodController(IPeriodMaster periodMaster)
        {
            _periodMaster = periodMaster;
        }
        #endregion

        #region Action Methods

        // GET: api/Period
        [HttpGet]
        public IEnumerable<PeriodTB> Get()
        {
            try
            {
                return _periodMaster.ListofPeriod();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
