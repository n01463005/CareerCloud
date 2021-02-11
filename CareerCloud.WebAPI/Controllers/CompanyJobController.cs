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
    public class CompanyJobController : ControllerBase
    {
        private readonly CompanyJobLogic _logic;

        public CompanyJobController()
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>();
            _logic = new CompanyJobLogic(repo);
        }

        [HttpGet]
        [Route("job/{jobid}")]
        [ResponseType(typeof(CompanyJobPoco))]
        public ActionResult GetCompanyJob(Guid jobid)
        {
            CompanyJobPoco poco = _logic.Get(jobid);
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("job")]
        [ResponseType(typeof(List<CompanyJobPoco>))]

        public ActionResult GetAllCompanyJob()
        {
            List<CompanyJobPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();

                
            }

            return Ok(poco);
        }

        [HttpPut]
        [Route("job")]

        public ActionResult PutCompanyJob([FromBody] CompanyJobPoco[] job)
        {
            try
            {
                _logic.Update(job);
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

        [HttpPost]
        [Route("job")]

        public ActionResult PostCompanyJob([FromBody] CompanyJobPoco[] job)
        {
            try
            {
                _logic.Add(job);
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
        [Route("job")]

        public ActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] job)
        {
            _logic.Delete(job);
            return Ok();
        }

    }
}
