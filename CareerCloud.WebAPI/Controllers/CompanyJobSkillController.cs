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
    public class CompanyJobSkillController : ControllerBase
    {
        private readonly CompanyJobSkillLogic _logic;
        public CompanyJobSkillController()

        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>();
            _logic = new CompanyJobSkillLogic(repo);
        }

        [HttpGet]
        [Route("jobSkill/{jobskillid}")]
        [ResponseType(typeof(CompanyJobSkillPoco))]

        public ActionResult GetCompanyJobSkill(Guid jobskillid)
        {
            CompanyJobSkillPoco poco = _logic.Get(jobskillid);
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpGet]
        [Route("jobskill")]
        [ResponseType(typeof(List<CompanyJobSkillPoco>))]

        public ActionResult GetAllCompanyJobSkill()
        {
            List<CompanyJobSkillPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("jobskill")]
        public ActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] jobskill)
        {
            try
            {
                _logic.Add(jobskill);
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
        [Route ("jobskill")]
        public ActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] jobskill)
        {
            try
            {
                _logic.Update(jobskill);
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
        [Route("jobskill")]
        public ActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] jobskill)
        {
            _logic.Delete(jobskill);
            return Ok();
        }
    }
}
