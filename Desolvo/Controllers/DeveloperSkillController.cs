using Desolvo.Models;
using Desolvo.services;
using Microsoft.AspNetCore.Mvc;

namespace Desolvo.Controllers
{
    [Route("api/developerskill")]
    [ApiController]
    public class DeveloperSkillController : ControllerBase
    {
        private readonly DeveloperSkillService _developerSkillService;

        public DeveloperSkillController(DeveloperSkillService developerSkillService)
        {
            _developerSkillService = developerSkillService;
        }

        [HttpPost]
        [Route("assign")]
        public ActionResult<DeveloperSkill> AssignSkill(int developerId, int skillId)
        {
            DeveloperSkill assignedDeveloperSkill = _developerSkillService.AssignSkill(developerId, skillId);

            if (assignedDeveloperSkill != null)
            {
                return Ok(assignedDeveloperSkill); // Return the assigned DeveloperSkill.
            }
            else
            {
                return BadRequest("Failed to assign skill."); // Handle assignment failure.
            }
        }

        [HttpDelete]
        [Route("delete-assignment")]
        public ActionResult DeleteAssignment(int developerId, int skillId)
        {
            bool isDeleted = _developerSkillService.DeleteAssignment(developerId, skillId);

            if (isDeleted)
            {
                return Ok("Skill assignment deleted successfully.");
            }
            else
            {
                return NotFound("Skill assignment not found.");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<DeveloperSkill> UpdateDeveloperSkill(int id, DeveloperSkill developerSkill)
        {
            DeveloperSkill updatedDeveloperSkill = _developerSkillService.UpdateDeveloperSkill(id, developerSkill);

            if (updatedDeveloperSkill != null)
            {
                return Ok(updatedDeveloperSkill); // Return the updated DeveloperSkill.
            }
            else
            {
                return NotFound("DeveloperSkill not found.");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DeveloperSkill> GetDeveloperSkill(int id)
        {
            DeveloperSkill developerSkill = _developerSkillService.GetDeveloperSkillById(id);

            if (developerSkill != null)
            {
                return Ok(developerSkill); // Return the retrieved DeveloperSkill.
            }
            else
            {
                return NotFound("DeveloperSkill not found.");
            }
        }
    }
}
