using Desolvo.Models;
using Desolvo.services;
using Microsoft.AspNetCore.Mvc;

namespace Desolvo.Controllers
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private DeveloperService _developerService = new DeveloperService();
        private SkillService _skillService = new SkillService();
        private DeveloperSkillService _developerSkillService = new DeveloperSkillService();

        // Creo un nuovo skill
        [HttpPost]
        public ActionResult<Skill> CreateSkill(Skill skill)
        {
            Skill createdSkill = _skillService.CreateSkill(skill.Name);

            if (createdSkill != null)
            {
                return CreatedAtRoute("GetSkill", new { id = createdSkill.ID }, createdSkill);
            }
            else
            {
                return BadRequest("Failed to create skill.");
            }
        }

        // Ottengo uno skill tramite il suo ID
        [HttpGet]
        [Route("{id}", Name = "GetSkill")]
        public ActionResult<Skill> GetSkill(int id)
        {
            Skill skill = _skillService.GetSkillById(id);

            if (skill != null)
            {
                return Ok(skill);
            }
            else
            {
                return NotFound();
            }
        }

        // aggiorno uno skill
        [HttpPut]
        [Route("{id}")]
        public ActionResult<Skill> UpdateSkill(int id, Skill skill)
        {
            Skill updatedSkill = _skillService.UpdateSkill(id, skill.Name);

            if (updatedSkill != null)
            {
                return Ok(updatedSkill);
            }
            else
            {
                return BadRequest("Failed to update skill.");
            }
        }

        // rimuovo uno skill se non assegnato ad un developer
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteSkill(int id)
        {
            bool deleted = _skillService.DeleteSkill(id);

            if (deleted)
            {
                return Ok("Skill deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete skill. It may be associated with a Developer.");
            }
        }
    }



}