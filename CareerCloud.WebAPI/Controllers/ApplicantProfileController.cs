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
    public class ApplicantProfileController : ControllerBase
    {
        private readonly ApplicantProfileLogic _logic;
        public ApplicantProfileController()
        {
            EFGenericRepository<ApplicantProfilePoco> repo = new EFGenericRepository<ApplicantProfilePoco>();
            _logic = new ApplicantProfileLogic(repo);
        }

        // get byu Id
        [HttpGet]
        [Route("Profile/{ProfileId}")]
        [ProducesResponseType(200, Type = typeof(ApplicantProfilePoco))]

        public ActionResult GetApplicantProfile(Guid ProfileId)
        {
            ApplicantProfilePoco poco = _logic.Get(ProfileId);
            if (poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("Profile")]
        [ProducesResponseType(200, Type = typeof(List<ApplicantProfilePoco>))]
        public ActionResult GetAllApplicantProfile()
        {
            List<ApplicantProfilePoco> poco = _logic.GetAll();
            if (poco is null)
            {
                return NotFound();

            }

            return Ok(poco);

        }

        [HttpPost]
        [Route("Profile")]

        public ActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] profile)
        {
            try
            {
                _logic.Add(profile);
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
        [Route("Profile")]
         public ActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] profile)
        {
            try
            {
                _logic.Update(profile);
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
        [Route("Profile")]
        public ActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] profile)
        {
            _logic.Delete(profile);
            return Ok();
        }
    }
}
