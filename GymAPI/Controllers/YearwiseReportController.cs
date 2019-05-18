using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymAPI.Interface;
using GymAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class YearwiseReportController : ControllerBase
    {
        #region Fields

        private readonly IReports _reports;
        #endregion

        #region Constructor

        public YearwiseReportController(IReports reports)
        {
            _reports = reports;
        }
        #endregion

        #region Action Methods

        // POST: api/YearwiseReport
        [HttpPost]
        public List<YearwiseReportViewModel> Post([FromBody] YearWiseRequestModel value)
        {
            return _reports.Get_YearwisePayment_details(value.YearID);
        }
        #endregion
    }
}
