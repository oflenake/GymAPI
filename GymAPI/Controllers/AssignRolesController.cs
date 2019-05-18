using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class AssignRolesController : ControllerBase
    {
        #region Fields

        private readonly IUsersInRoles _usersInRoles;
        #endregion

        #region Constructor

        public AssignRolesController(IUsersInRoles usersInRoles)
        {
            _usersInRoles = usersInRoles;
        }
        #endregion

        #region Action Methods
        // GET: api/UsersInRoles
        [HttpGet]
        public IEnumerable<AssignRolesViewModel> Get()
        {
            try
            {
                return _usersInRoles.GetAssignRoles();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/UsersInRoles
        [HttpPost]
        public HttpResponseMessage Post([FromBody] UsersInRoles usersInRoles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_usersInRoles.CheckRoleExists(usersInRoles))
                    {
                        var response = new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.Conflict    // Status code: 409
                        };
                        return response;
                    }
                    else
                    {
                        usersInRoles.UserRolesId = 0;
                        _usersInRoles.AssignRole(usersInRoles);

                        var response = new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK      // Status code: 200
                        };
                        return response;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.BadRequest  // Status code: 400
                    };
                    return response;
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
