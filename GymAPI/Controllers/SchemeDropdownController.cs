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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchemeDropdownController : ControllerBase
    {
        #region Fields

        private readonly ISchemeMaster _schemeMaster;
        #endregion

        #region Constructor

        public SchemeDropdownController(ISchemeMaster schemeMaster)
        {
            _schemeMaster = schemeMaster;
        }
        #endregion

        #region Action Methods

        // GET: api/SchemeDropdown
        [HttpGet]
        public IEnumerable<SchemeMaster> Get()
        {
            try
            {
                return _schemeMaster.GetActiveSchemeMasterList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
