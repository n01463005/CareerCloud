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
    public class CompanyProfileController : ControllerBase
    {
        private readonly CompanyProfileLogic _logic;
        public CompanyProfileController()
        {
            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>();
            _logic = new CompanyProfileLogic(repo);
    
        }

        [HttpGet]
        [Route("profile/{profid}")]
        [ResponseType(typeof(CompanyProfilePoco))]

        public ActionResult GetCompanyProfile(Guid profid)
        {
            CompanyProfilePoco poco = _logic.Get(profid);
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }
       [HttpGet]
       [Route("profile")]
        [ResponseType(typeof(List<CompanyProfilePoco>))]

        public ActionResult GetAllCompanyProfile()
        {
            List<CompanyProfilePoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();

            }
            return Ok(poco);
        }

        [HttpPut]
        [Route("profile")]

        public ActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] profile)
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

        [HttpPost]
        [Route("profile")]
        public ActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] profile)
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

        [HttpDelete]
        [Route("profile")]
        public ActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] profile)
        {
            _logic.Delete(profile);
            return Ok();
        }
    
    }


}
