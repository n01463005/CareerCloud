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
    [Route("api/careercloud/applicant/v1")]
    [ApiController]
    public class ApplicantJobApplicationController : ControllerBase
    {
       private readonly ApplicantJobApplicationLogic _logic;
        public ApplicantJobApplicationController()
        {
            EFGenericRepository<ApplicantJobApplicationPoco> repo = new EFGenericRepository<ApplicantJobApplicationPoco>();

            _logic = new ApplicantJobApplicationLogic(repo);
        }
        // Get by Id
        [HttpGet]
        [Route("jobApplication/{applicantJobApplicationId}")]
        [ProducesResponseType(200,Type=typeof(ApplicantJobApplicationPoco))]
        public ActionResult GetApplicantJobApplication(Guid applicantJobApplicationId)
        {
            ApplicantJobApplicationPoco poco = _logic.Get(applicantJobApplicationId);
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        // Get All
        [HttpGet]
        [Route("jobApplication")]
        [ProducesResponseType(200,Type=typeof(List<ApplicantJobApplicationPoco>))]
        public ActionResult GetApplicantJobApplication()
        {
            List<ApplicantJobApplicationPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        // Post ~ Create
        [HttpPost]
        [Route("jobApplication")]
        public ActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] jobApplication)
        {
            try
            {
                _logic.Add(jobApplication);
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

        // Put ~ Update
        [HttpPut]
        [Route("jobApplication")]
         public ActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] jobApplication)
        {
            try
            {
                _logic.Update(jobApplication);
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
        [Route("jobApplication")]

        public ActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] jobApplication)
        {
            _logic.Delete(jobApplication);
            return Ok();
        }
    }
}
