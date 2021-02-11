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
    public class ApplicantSkillController : ControllerBase
    {
       
         private readonly ApplicantSkillLogic _logic;
        public ApplicantSkillController ()
            {
            EFGenericRepository<ApplicantSkillPoco> repo = new EFGenericRepository<ApplicantSkillPoco>();
                _logic = new ApplicantSkillLogic(repo);
            }
        [HttpGet]
        [Route("Skill/{skillid}")]
        [ResponseType(typeof(ApplicantSkillPoco))]

        public ActionResult GetApplicantSkill(Guid skillid)
        {
            ApplicantSkillPoco poco = _logic.Get(skillid);
            if (poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }
        [HttpGet]
        [Route("skill")]
        [ResponseType(typeof(List<ApplicantSkillPoco>))]

        public ActionResult GetApplicantSkill()
        {
            List<ApplicantSkillPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpPost]
        [Route("skill")]

        public ActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] skill)
        {
            try
            {
                _logic.Add(skill);
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
        [Route("skill")]
        public ActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] skill)
        {
            try
            {
                _logic.Update(skill);
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
        [Route("skill")]
        public ActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] skill)
        {
            _logic.Delete(skill);
            return Ok();
        }

      }
    }


