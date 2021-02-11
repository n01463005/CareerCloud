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
    public class ApplicantWorkHistoryController : ControllerBase
    {
        private readonly ApplicantWorkHistoryLogic _logic;
        public ApplicantWorkHistoryController()
        {
            EFGenericRepository<ApplicantWorkHistoryPoco> repo = new EFGenericRepository<ApplicantWorkHistoryPoco>();
            _logic = new ApplicantWorkHistoryLogic(repo);
        }

        [HttpGet]
        [Route("WorkHistory/{workid}")]
        [ResponseType(typeof(ApplicantWorkHistoryPoco))]

        public ActionResult GetApplicantWorkHistory(Guid workid)
        {
            ApplicantWorkHistoryPoco poco = _logic.Get(workid);
            if(poco == null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("workHistory")]
        [ResponseType(typeof(List<ApplicantWorkHistoryPoco>))]
        public ActionResult GetAllApplicantWorkHistory()
        {
            List<ApplicantWorkHistoryPoco> poco = _logic.GetAll();
            if (poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }
        [HttpPost]
        [Route("workHistory")]

        public ActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] workHistory)
        {
            try
            {
                _logic.Add(workHistory);
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
        [Route("workHistory")]

        public ActionResult PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] workHistory)
        {
            try
            {
                _logic.Update(workHistory);
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
        [Route("work")]

        public ActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] work)
        {
            _logic.Delete(work);
            return Ok();
        }
    }
}
