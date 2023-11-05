using Desolvo.Models;
using Desolvo.services;
using Microsoft.AspNetCore.Mvc;

namespace Desolvo.Controllers
{
    [Route("api/developerskills")]
    public class DeveloperSkillController : ControllerBase
    {
        private DeveloperSkillService _developerSkillService = new DeveloperSkillService();

        // Creo un nuovo DeveloperSkill
        [HttpPost]
        public ActionResult<DeveloperSkill> CreateDeveloperSkill(DeveloperSkill developerSkill)
        {
            DeveloperSkill createdDeveloperSkill = _developerSkillService.CreateDeveloperSkill(developerSkill.DeveloperID, developerSkill.SkillID);

            if (createdDeveloperSkill != null)
            {
                return CreatedAtRoute("GetDeveloperSkill", new { id = createdDeveloperSkill.ID }, createdDeveloperSkill);
            }
            else
            {
                return BadRequest("Failed to create Developer-Skill association.");
            }
        }

        // ottengo un DeveloperSkill tramite il suo ID
        [HttpGet]
        [Route("{id}", Name = "GetDeveloperSkill")]
        public ActionResult<DeveloperSkill> GetDeveloperSkill(int id)
        {
            DeveloperSkill developerSkill = _developerSkillService.GetDeveloperSkillById(id);

            if (developerSkill != null)
            {
                return Ok(developerSkill);
            }
            else
            {
                return NotFound();
            }

            // aggiorno un DeveloperSkill
            [HttpPut]
            [Route("{id}")]
            ActionResult<DeveloperSkill> UpdateDeveloperSkill(int id, DeveloperSkill developerSkill)
            {
                DeveloperSkill existingDeveloperSkill = _developerSkillService.GetDeveloperSkillById(id);

                if (existingDeveloperSkill == null)
                {
                    return NotFound(); // Ritorna un errore 404 se non trova nulla.
                }

                // aggiorno il DeveloperSkill con dati dalla richiesta
                existingDeveloperSkill.DeveloperID = developerSkill.DeveloperID;
                existingDeveloperSkill.SkillID = developerSkill.SkillID;


                return Ok(existingDeveloperSkill);
            }


            // rimuovo un DeveloperSkill
            [HttpDelete]
            [Route("{id}")]
            ActionResult DeleteDeveloperSkill(int id)
            {
                
                bool isDeleted = _developerSkillService.DeleteDeveloperSkill(id);

                if (isDeleted)
                {
                    return Ok("DeveloperSkill deleted successfully.");
                }
                else
                {
                    return BadRequest("Failed to delete DeveloperSkill.");
                }
            }
        }
    }
}
