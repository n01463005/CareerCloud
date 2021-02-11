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
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private readonly CompanyJobDescriptionLogic _logic;
        public CompanyJobsDescriptionController()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("jobDescription/{jobdescid}")]
        [ProducesResponseType(200,Type=typeof(CompanyJobDescriptionPoco))]
        
        public ActionResult GetCompanyJobsDescription(Guid jobdescid)
        {
            CompanyJobDescriptionPoco poco = _logic.Get(jobdescid);
            if (poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("jobDescription")]
        [ProducesResponseType(200, Type=typeof(List<CompanyJobDescriptionPoco>))]
        public ActionResult GetAllCompanyJobDescription()
        {
            List<CompanyJobDescriptionPoco> poco = _logic.GetAll();
            if(poco == null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("jobDescription")]

        public ActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] jobDescription)
        {
            try
            {
                _logic.Add(jobDescription);
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
        [Route("jobDescription")]

        public ActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] jobDescription)
        {
            try
            {
                _logic.Update(jobDescription);
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
        [Route("jobDescription")]

        public ActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] jobDescription)
        {
            _logic.Delete(jobDescription);
            return Ok();
        }
    }
}
