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
    public class ApplicantResumeController : ControllerBase
    {
        private readonly ApplicantResumeLogic _logic;
        public ApplicantResumeController()
        {
            EFGenericRepository<ApplicantResumePoco> repo = new EFGenericRepository<ApplicantResumePoco>();
            _logic = new ApplicantResumeLogic(repo);
        }

        [HttpGet]
        [Route("Resume/{Resumeid}")]
        [ProducesResponseType(200, Type = typeof(ApplicantResumePoco))]

        public ActionResult GetApplicantResume(Guid Resumeid)
        {
            ApplicantResumePoco poco = _logic.Get(Resumeid);
            if (poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route ("Resume")]
        [ProducesResponseType(200, Type = typeof(List<ApplicantResumePoco>))]
        public ActionResult GetApplicantResume()
        {
            List<ApplicantResumePoco> poco = _logic.GetAll();

                if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("Resume")]
        public ActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] Resume)
        {
            try
            {
                _logic.Add(Resume);
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
        [Route("Resume")]
        public ActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] Resume)
        {
            try
            {
                _logic.Update(Resume);
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
        [Route("Resume")]
        public ActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] Resume)
        {
            _logic.Delete(Resume);
            return Ok();
        }
    }
}
