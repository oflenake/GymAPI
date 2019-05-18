using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public class GetTotalAmountController : ControllerBase
    {
        #region Fields

        private readonly IPlanMaster _planMaster;
        #endregion

        #region Constructor

        public GetTotalAmountController(IPlanMaster planMaster)
        {
            _planMaster = planMaster;
        }
        #endregion

        #region Action Methods
        // POST: api/GetTotalAmount
        [HttpPost]
        public string Post([FromBody] AmountRequestViewModel amountRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _planMaster.GetAmount(amountRequest.PlanId, amountRequest.SchemeId);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
