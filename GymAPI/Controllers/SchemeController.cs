using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymAPI.Interface;
using GymAPI.Models;
using GymAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchemeController : ControllerBase
    {
        #region Fields

        private readonly ISchemeMaster _schemeMaster;
        #endregion

        #region Constructor

        public SchemeController(ISchemeMaster schemeMaster)
        {
            _schemeMaster = schemeMaster;
        }
        #endregion

        #region Action Methods

        // GET: api/Scheme
        [HttpGet]
        public List<SchemeMaster> Get()
        {
            return _schemeMaster.GetSchemeMasterList();
        }

        // GET: api/Scheme/5
        [HttpGet("{id}", Name = "GetScheme")]
        public SchemeMaster Get(int id)
        {
            return _schemeMaster.GetSchemeMasterbyId(id);
        }

        // POST: api/Scheme
        [HttpPost]
        public HttpResponseMessage Post([FromBody] SchemeMasterViewModel schemeMaster)
        {
            if (ModelState.IsValid)
            {
                if (_schemeMaster.CheckSchemeNameExists(schemeMaster.SchemeName))
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.Conflict            // Status code: 409
                    };
                    return response;
                }
                else
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.Name);

                    var tempSchemeMaster = AutoMapper.Mapper.Map<SchemeMaster>(schemeMaster);
                    tempSchemeMaster.Createddate = DateTime.Now;
                    tempSchemeMaster.Createdby = Convert.ToInt32(userId);
                    _schemeMaster.AddSchemeMaster(tempSchemeMaster);

                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK                  // Status code: 200
                    };
                    return response;
                }
            }
            else
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest              // Status code: 400
                };
                return response;
            }
        }

        // PUT: api/Scheme/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] SchemeMasterEditViewModel schemeMaster)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(id)) || schemeMaster == null)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest              // Status code: 400
                };
                return response;
            }
            else
            {
                var temp = AutoMapper.Mapper.Map<SchemeMaster>(schemeMaster);
                var result = _schemeMaster.UpdateSchemeMaster(temp);

                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK                      // Status code: 200
                };
                return response;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = _schemeMaster.DeleteScheme(id);

            if (result)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK                      // Status code: 200
                };
                return response;
            }
            else
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest              // Status code: 400
                };
                return response;
            }
        }
        #endregion
    }
}
