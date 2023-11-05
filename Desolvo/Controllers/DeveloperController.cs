using Desolvo.Models;
using Desolvo.services;
using Microsoft.AspNetCore.Mvc;

namespace Desolvo.Controllers
{
    [Route("api/developers")]
    public class DeveloperController : ControllerBase
    {
        private DeveloperService _developerService = new DeveloperService();
        private DeveloperSkillService _developerSkillService = new DeveloperSkillService();

        // Crea un nuovo developer usando il metodo http POST:
        [HttpPost]
        public ActionResult<Developer> CreateDeveloper(Developer developer)
        {
            Developer createdDeveloper = _developerService.CreateDeveloper(developer.Name, developer.Surname);

            if (createdDeveloper != null)
            {
                return CreatedAtRoute("GetDeveloper", new { id = createdDeveloper.ID }, createdDeveloper);
            }
            else
            {
                return BadRequest("Failed to create developer.");
            }
        }

        // Ottengo un Developer tramite ID con il metodo http GET
        [HttpGet]
        [Route("{id}", Name = "GetDeveloper")]
        public ActionResult<Developer> GetDeveloper(int id)
        {
            Developer developer = _developerService.GetDeveloperById(id);

            if (developer != null)
            {
                return Ok(developer);
            }
            else
            {
                return NotFound();
            }
        }

        // aggiorno un Developer con il metodo http PUT
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Developer> UpdateDeveloper(int id, Developer developer)
        {
            Developer updatedDeveloper = _developerService.UpdateDeveloper(id, developer.Name, developer.Surname);
            if (updatedDeveloper == null)
            {
                return NotFound();
            }
            if (updatedDeveloper != null)
            {
                return Ok(updatedDeveloper);
            }
            else
            {
                return BadRequest("Failed to update developer.");
            }
        }

        // rimuovo un developer (se non ha uno Skill) con il metodo http DELETE
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDeveloper(int id)
        {
            bool deleted = _developerService.DeleteDeveloper(id);

            if (deleted)
            {
                return Ok("Developer deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete developer. It may be associated with a Skill.");
            }
        }
    }

}
