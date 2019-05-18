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
    public class AllActivePlanMasterController : ControllerBase
    {
        #region Fields

        private readonly IPlanMaster _planMaster;
        #endregion

        #region Constructor

        public AllActivePlanMasterController(IPlanMaster planMaster)
        {
            _planMaster = planMaster;
        }
        #endregion

        #region Action Methods

        // GET: api/AllActivePlanMaster/5
        [HttpGet("{id}", Name = "GetAllActivePlan")]
        public List<ActivePlanModel> Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    return _planMaster.GetActivePlanMasterList(id);
                }
                else
                {
                    return new List<ActivePlanModel>()
                    {
                        new ActivePlanModel()
                        {
                            PlanID = string.Empty,
                            PlanName = ""
                        }
                    };
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
