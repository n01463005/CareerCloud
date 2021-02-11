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
    public class SecurityLoginsLogController : ControllerBase
    {

        private readonly SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogController()
        {
            EFGenericRepository<SecurityLoginsLogPoco> repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _logic = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("loginsLog/{logid}")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]

        public ActionResult GetSecurityLoginLog(Guid logid)
        {
            SecurityLoginsLogPoco poco = _logic.Get(logid);
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("loginLog")]
        [ResponseType(typeof(List<SecurityLoginsLogPoco>))]

        public ActionResult GetAllSecuriyLoginLog()
        {
            List<SecurityLoginsLogPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpPost]
        [Route("loginLog")]

        public ActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] loginLog)
        {
            try
            {
                _logic.Add(loginLog);
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
        [Route("loginLog")]

        public ActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] loginLog)
        {
            try
            {
                _logic.Update(loginLog);
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
        [Route("loginLog")]

        public ActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] loginLog)
        {
            _logic.Delete(loginLog);
                return Ok();
        }
    }
}
