using Desolvo.Data;
using Desolvo.Models;

namespace Desolvo.services
{
    public class DeveloperSkillService
    {
        // Creare un nuovo DeveloperSkill
        public DeveloperSkill CreateDeveloperSkill(int developerId, int skillId)
        {
            DeveloperSkill newDeveloperSkill = new DeveloperSkill
            {
                ID = GenerateDeveloperSkillId(),
                DeveloperID = developerId,
                SkillID = skillId
            };

            FakeDatabase.DeveloperSkills.Add(newDeveloperSkill);
            return newDeveloperSkill;
        }

        // verificare se un developer ha degli skill associati
        public bool HasDeveloperSkills(int developerId)
        {
            return FakeDatabase.DeveloperSkills.Any(ds => ds.DeveloperID == developerId);
        }

        // verificare se un uno skill è associato a degli developer
        public bool HasSkillDevelopers(int skillId)
        {
            return FakeDatabase.DeveloperSkills.Any(ds => ds.SkillID == skillId);
        }

        // metodo che genera un id unico per developerskill
        private int GenerateDeveloperSkillId()
        {
            return FakeDatabase.DeveloperSkills.Count > 0
                ? FakeDatabase.DeveloperSkills.Max(ds => ds.ID) + 1
                : 1;
        }

        // ottenere un DeveloperSkill tramite ID
        public DeveloperSkill GetDeveloperSkillById(int id)
        {
            return FakeDatabase.DeveloperSkills.FirstOrDefault(ds => ds.ID == id);
        }

        // rimuovere un DeveloperSkill tramite ID
        public bool DeleteDeveloperSkill(int id)
        {
            DeveloperSkill developerSkillToDelete = FakeDatabase.DeveloperSkills.FirstOrDefault(ds => ds.ID == id);

            if (developerSkillToDelete != null)
            {
                FakeDatabase.DeveloperSkills.Remove(developerSkillToDelete);
                return true; 
            }

            return false; 
        }

    }

}
