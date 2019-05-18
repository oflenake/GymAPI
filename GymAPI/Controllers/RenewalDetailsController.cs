using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class RenewalDetailsController : ControllerBase
    {
        #region Fields

        private readonly IRenewal _renewal;
        #endregion

        #region Constructor

        public RenewalDetailsController(IRenewal renewal)
        {
            _renewal = renewal;
        }
        #endregion

        #region Action Methods

        // POST: api/RenewalDetails
        [HttpPost]
        public RenewalViewModel Post([FromBody] MemberNoRequest memberNoRequest)
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            return _renewal.GetMemberNo(memberNoRequest.MemberNo, userId);
        }
        #endregion
    }
}
