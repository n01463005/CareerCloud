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
    public class SecurityRoleController : ControllerBase
    {
        private readonly SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            EFGenericRepository<SecurityRolePoco> repo = new EFGenericRepository<SecurityRolePoco>();
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("role/{sroleid}")]
        [ResponseType(typeof(SecurityRolePoco))]

        public ActionResult GetSecurityRole(Guid sroleid)
        {
            SecurityRolePoco poco = _logic.Get(sroleid);
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("role")]
        [ResponseType(typeof(List<SecurityRolePoco>))]
        public ActionResult GetAllSecurityRole()
         {
            List<SecurityRolePoco> poco = _logic.GetAll();
                if(poco is null)
                {
                    return NotFound();
                }
                return Ok(poco);
         
         }

        [HttpPost]
        [Route("role")]

        public ActionResult PostSecurityRole([FromBody] SecurityRolePoco[] role)
        {
            try
            {
                _logic.Add(role);
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
        [Route("role")]

        public ActionResult PutSecurityRole([FromBody] SecurityRolePoco[] role)
        {
            try
            {
                _logic.Update(role);
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
        [Route("role")]

         public ActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] role)
        {
            _logic.Delete(role);
            return Ok();
        }
    }
}
