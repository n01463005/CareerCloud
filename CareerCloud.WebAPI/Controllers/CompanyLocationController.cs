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
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyLocationController : ControllerBase
    {
        private readonly CompanyLocationLogic _logic;
        public CompanyLocationController()
        {
            EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>();
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("location/{locationid}")]
        [ResponseType(typeof(CompanyLocationPoco))]

        public ActionResult GetCompanyLocation(Guid locationid)
        {
            CompanyLocationPoco poco = _logic.Get(locationid);
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("location")]
        [ProducesResponseType(200, Type=typeof(List<CompanyLocationPoco>))]
        public ActionResult GetAllCompanyLocation()
        {
            List<CompanyLocationPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpPost]
        [Route("location")]
        public ActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] location)
        {
            try
            {
                _logic.Add(location);
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
        [Route("location")]

        public ActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] location)
        {
            try
            {
                _logic.Update(location);
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
        [Route("location")]
        public ActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] location)
        {
            _logic.Delete(location);
            return Ok();
        }
    }
}
