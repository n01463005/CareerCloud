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
    public class CompanyDescriptionController : ControllerBase
    {
        private readonly CompanyDescriptionLogic _logic;
        public CompanyDescriptionController()
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>();
            _logic = new CompanyDescriptionLogic(repo);    
        }

        [HttpGet]
        [Route("description/{descriptionid}")]
        [ResponseType(typeof(CompanyDescriptionPoco))]

        public ActionResult GetCompanyDescription(Guid descriptionid)
        {
            CompanyDescriptionPoco poco = _logic.Get(descriptionid);
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("description")]
        [ResponseType(typeof(List<CompanyDescriptionPoco>))]

        public ActionResult GetCompanyDescription()
        {
            List<CompanyDescriptionPoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }

            return Ok(poco);
        }

        [HttpPost]
        [Route("description")]

        public ActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] description)
        {
            try
            {
                _logic.Add(description);
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
        [Route("description")]

        public ActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] description)
        {
            try
            {
                _logic.Update(description);
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
        [Route("description")]
        public ActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] description)
        {
            _logic.Delete(description);
            return Ok();
        }
    }
}
