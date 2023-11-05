using Desolvo.Data;
using Desolvo.Models;

namespace Desolvo.services
{
    public class SkillService
    {
        // Creare un nuovo Skill
        public Skill CreateSkill(string name)
        {
            Skill newSkill = new Skill
            {
                ID = GenerateSkillId(),
                Name = name
            };

            FakeDatabase.Skills.Add(newSkill);
            return newSkill;
        }

        // Ottenere uno Skill tramite ID
        public Skill GetSkillById(int id)
        {
            return FakeDatabase.Skills.FirstOrDefault(skill => skill.ID == id);
        }

        // Aggiornare uno skill esistente
        public Skill UpdateSkill(int id, string name)
        {
            Skill existingSkill = FakeDatabase.Skills.FirstOrDefault(skill => skill.ID == id);

            if (existingSkill != null)
            {
                existingSkill.Name = name;
            }

            return existingSkill;
        }

        // rimuovere uno skill tramite ID
        public bool DeleteSkill(int id)
        {
            Skill existingSkill = FakeDatabase.Skills.FirstOrDefault(skill => skill.ID == id);

            if (existingSkill != null)
            {
                // verificare se uno skill è associato a dei developer, se è così non rimuovere
                if (HasSkillDevelopers(id))
                {
                    return false; // Skill associato.
                }

                FakeDatabase.Skills.Remove(existingSkill);
                return true; // rimosso.
            }

            return false; // Skill non trovato.
        }

        // verificare se uno skill è associato con dei developer
        private bool HasSkillDevelopers(int skillId)
        {
            return FakeDatabase.DeveloperSkills.Any(ds => ds.SkillID == skillId);
        }

        // metodo che genera un unico id per skill
        private int GenerateSkillId()
        {
            return FakeDatabase.Skills.Count > 0
                ? FakeDatabase.Skills.Max(skill => skill.ID) + 1
                : 1;
        }
    }


}
