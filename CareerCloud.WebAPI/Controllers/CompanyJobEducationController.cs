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
    public class CompanyJobEducationController : ControllerBase
    {
        private readonly CompanyJobEducationLogic _logic;
        public CompanyJobEducationController()
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _logic = new CompanyJobEducationLogic(repo);   
        }

        [HttpGet]
        [Route("jobEducation/{jobeduid}")]
        [ResponseType(typeof(CompanyJobEducationPoco))]

        public ActionResult GetCompanyJobEducation(Guid jobeduid)
        {
            CompanyJobEducationPoco poco = _logic.Get(jobeduid);
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("jobEducation")]
        [ResponseType(typeof(List<CompanyJobEducationPoco>))]
        public ActionResult GetAllCompanyJobEducation()
        {
            List<CompanyJobEducationPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("jobEducation")]
        public ActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] jobEducation)
        {
            try
            {
                _logic.Add(jobEducation);
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
        [Route("jobEducation")]
        public ActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] jobEducation)
        {
            try
            {
                _logic.Update(jobEducation);
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
        [Route("jobEducation")]

        public ActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] jobEducation)
        {
            _logic.Delete(jobEducation);
            return Ok();
        }
    }
}
