using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymAPI.Interface;
using GymAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateRecepitController : ControllerBase
    {
        #region Fields

        private readonly IGenerateRecepit _generateRecepit;
        #endregion

        #region Constructor

        public GenerateRecepitController(IGenerateRecepit generateRecepit)
        {
            _generateRecepit = generateRecepit;
        }
        #endregion

        #region Action Methods
        // POST: api/GenerateRecepit
        [HttpPost]
        public GenerateRecepitViewModel Post([FromBody] GenerateRecepitRequestModel generateRecepitRequestModel)
        {
            try
            {
                return _generateRecepit.Generate(generateRecepitRequestModel.PaymentId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
