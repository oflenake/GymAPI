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
    public class GetMemberNoController : ControllerBase
    {
        #region Fields

        private readonly IMemberRegistration _memberRegistration;
        #endregion

        #region Constructor

        public GetMemberNoController(IMemberRegistration memberRegistration)
        {
            _memberRegistration = memberRegistration;
        }
        #endregion

        #region Action Methods

        // POST: api/GetMemberNo
        [HttpPost]
        public List<MemberResponse> Post([FromBody] MemberRequest memberRequest)
        {
            try
            {
                var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
                return _memberRegistration.GetMemberNoList(memberRequest.MemberName, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
