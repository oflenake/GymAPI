using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GymAPI.Common;
using GymAPI.Interface;
using GymAPI.Models;
using GymAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        #region Fields

        private readonly IPaymentDetails _paymentDetails;
        private readonly IUrlHelper _urlHelper;
        #endregion

        #region Constructor

        public PaymentController(IUrlHelper urlHelper, IPaymentDetails paymentDetails)
        {
            _paymentDetails = paymentDetails;
            _urlHelper = urlHelper;
        }
        #endregion

        #region Action Methods

        // GET: api/Payment
        [HttpGet(Name = "GetAllPayment")]
        public IActionResult GetAllPayment([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));

                List<PaymentDetailsViewModel> allMembers = _paymentDetails.GetAll(queryParameters, userId).ToList();

                var allItemCount = _paymentDetails.Count(userId);

                var paginationMetadata = new
                {
                    totalCount = allItemCount,
                    pageSize = queryParameters.PageCount,
                    currentPage = queryParameters.Page,
                    totalPages = queryParameters.GetTotalPages(allItemCount)
                };

                Request.HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

                return Ok(new
                {
                    value = allMembers
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
