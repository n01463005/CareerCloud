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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemLanguageCodeController : ControllerBase
    {
        private readonly SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
            EFGenericRepository<SystemLanguageCodePoco> repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("languageCode /{lanid}")]
        [ResponseType(typeof(SystemLanguageCodePoco))]
        public ActionResult GetSystemLanguageCode(string lanid)
        {
            SystemLanguageCodePoco poco = _logic.Get(lanid);
            if(poco is null)
            {
                return NotFound();
            }
            return Ok(poco);
        }

        [HttpGet]
        [Route("languageCode")]
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public ActionResult GetAllSystemLanguageCode()
        {
            List<SystemLanguageCodePoco> poco = _logic.GetAll();
            if(poco is null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        [Route("languageCode")]
        public ActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] languageCode)
        {
            try
            {
                _logic.Update(languageCode);
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
        [Route("languageCode")]
        public ActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] languageCode)
        {
            try
            {
                _logic.Add(languageCode);
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
        [Route("languageCode")]
        public ActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] languageCode)
        {
            _logic.Delete(languageCode);
            return Ok();
        }
    }
}
