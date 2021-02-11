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
    public class ApplicantEducationController : ControllerBase
    {
        private readonly ApplicantEducationLogic _logic;
        public ApplicantEducationController()
        {
            EFGenericRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>();
            //ApplicantEducationLogic logic = new ApplicantEducationLogic(repo);
            _logic = new ApplicantEducationLogic(repo);
        }

        // Get by Id
        [HttpGet]
        [Route("education/{applicantEducationId}")]
        [ResponseType(typeof(ApplicantEducationPoco))]
        public ActionResult GetApplicantEducation(Guid applicantEducationId)
        {
            ApplicantEducationPoco poco = _logic.Get(applicantEducationId);

            if(poco == null) // or if (poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        // Get all
        [HttpGet]
        [Route("education")]
        [ResponseType(typeof(List<ApplicantEducationPoco>))]

        public ActionResult GetAllApplicantEducation()
        {
            List<ApplicantEducationPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        // Post verb ~ Create

        [HttpPost]
        [Route("education")]

        public ActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] education)
   
        {
            try
            {
                _logic.Add(education);
                return Ok();
            }
            catch(AggregateException e)
            {
                return BadRequest(e);
            }
            catch
            {
                return StatusCode(500);
            }
        }


        // Put verb ~ Update
        [HttpPut]
        [Route("education")]
        public ActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] education)
        {
            try
            {
                _logic.Update(education);
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

        // Delete verb
        [HttpDelete]
        [Route("education")]

        public ActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] education)
        {
            _logic.Delete(education);
            return Ok();
        }
    }
}
