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
    public class MemberDetailsReportController : ControllerBase
    {
        #region Fields

        private readonly IReports _reports;
        #endregion

        #region Constructor

        public MemberDetailsReportController(IReports reports)
        {
            _reports = reports;
        }
        #endregion

        #region Action Methods
        // GET: api/MemberDetailsReport
        [HttpGet]
        public List<MemberDetailsReportViewModel> Get()
        {
            try
            {
                return _reports.Generate_AllMemberDetailsReport();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
