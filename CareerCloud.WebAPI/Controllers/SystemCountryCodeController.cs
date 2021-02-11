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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemCountryCodeController : ControllerBase
    {
        private readonly SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
            EFGenericRepository<SystemCountryCodePoco> repo = new EFGenericRepository<SystemCountryCodePoco>(); 
            _logic = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("countryCode/{counid}")]
        [ResponseType(typeof(SystemCountryCodePoco))]

        public ActionResult GetSystemCountryCode(string counid)
        {
            SystemCountryCodePoco poco = _logic.Get(counid);
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("countryCode")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]

        public ActionResult GetAllSystemCountryCode()
        {
            List<SystemCountryCodePoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        [Route("countryCode")]
        public ActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] countryCode)
        {
            try
            {
                _logic.Add(countryCode);
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
        [Route("countryCode")]
        public ActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] countryCode)
        {
            try
            {
                _logic.Update(countryCode);
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
        [Route("countryCode")]
        public ActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] countryCode)
        {
            _logic.Delete(countryCode);
            return Ok();
        }
    }
}
