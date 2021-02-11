using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1")]
    [ApiController]
    public class SecurityLoginsRoleController : ControllerBase
    {
        private readonly SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {

            EFGenericRepository<SecurityLoginsRolePoco> repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("loginsRole/{roleid}")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]

        public ActionResult GetSecurityLoginsRole(Guid roleid)
        {
            SecurityLoginsRolePoco poco = _logic.Get(roleid);
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("loginRole")]
        [ResponseType(typeof(List<SecurityLoginsRolePoco>))]
        public ActionResult GetAllSecurityLoginsRole()
        {
            List<SecurityLoginsRolePoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        [Route("loginRole")]

        public ActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] loginRole)
        {
            try
            {
                _logic.Add(loginRole);
                return Ok();
            }
            catch (AggregateException e)
            {
                return BadRequest(e);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("loginRole")]

        public ActionResult PutSecurityLoginRole ( [FromBody] SecurityLoginsRolePoco[] loginRole)
        {
            try
            {
                _logic.Update(loginRole);
                return Ok();
            }
            catch (AggregateException e)
            {
                return BadRequest(e);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("loginRole")]

        public ActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] loginRole)
        {
            _logic.Delete(loginRole);
            return Ok();
        }
    }
}
