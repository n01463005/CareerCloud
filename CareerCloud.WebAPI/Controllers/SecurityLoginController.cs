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
    public class SecurityLoginController : ControllerBase
    {
        private readonly SecurityLoginLogic _logic;
        public SecurityLoginController()
        {
            EFGenericRepository<SecurityLoginPoco> repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(repo);
        }

        [HttpGet]
        [Route("login/{loginid}")]
        [ResponseType(typeof(SecurityLoginPoco))]

        public ActionResult GetSecurityLogin(Guid loginid)
        {
            SecurityLoginPoco poco = _logic.Get(loginid);
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("login")]
        [ResponseType(typeof(List<CompanyDescriptionPoco>))]
        [ResponseType(typeof(List<SecurityLoginPoco>))]

        public ActionResult GetSecurityLOginall()
        {
            List<SecurityLoginPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpPost]
        [Route("login")]
        public ActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] login)
        {
            try
            {
                _logic.Add(login);
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
        [Route("login")]
        public ActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] login)
        {
            try
            {
                _logic.Update(login);
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
        [Route("login")]

        public ActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] login)
        {
            _logic.Delete(login);
            return Ok();
        }
    }
}
