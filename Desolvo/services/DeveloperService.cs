using Desolvo.Data;
using Desolvo.Models;

namespace Desolvo.services
{
    
        public class DeveloperService
        {
            // Creare un nuovo Developer
            public Developer CreateDeveloper(string name, string surname)
            {
                Developer newDeveloper = new Developer
                {
                    ID = GenerateDeveloperId(),
                    Name = name,
                    Surname = surname
                };

                FakeDatabase.Developers.Add(newDeveloper);
                return newDeveloper;
            }

            // Ottenere un Developer tramite ID
            public Developer GetDeveloperById(int id)
            {
                return FakeDatabase.Developers.FirstOrDefault(dev => dev.ID == id);
            }

            // Aggiornare un Developer
            public Developer UpdateDeveloper(int id, string name, string surname)
            {
                Developer existingDeveloper = FakeDatabase.Developers.FirstOrDefault(dev => dev.ID == id);

                if (existingDeveloper != null)
                {
                    existingDeveloper.Name = name;
                    existingDeveloper.Surname = surname;
                }

                return existingDeveloper;
            }

            // Rimuovere un Developer tramite ID
            public bool DeleteDeveloper(int id)
            {
                Developer existingDeveloper = FakeDatabase.Developers.FirstOrDefault(dev => dev.ID == id);

                if (existingDeveloper != null)
                {
                    // verificare se il developer ha degli skill associati e nel caso, non rimuobere
                    if (HasDeveloperSkills(id))
                    {
                        return false; 
                    }

                    FakeDatabase.Developers.Remove(existingDeveloper);
                    return true;
                }

                return false; // Developer non trovato.
            }

            // Creare un nuovo skill
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

            // Aggiornare uno Skill esistente
            public Skill UpdateSkill(int id, string name)
            {
                Skill existingSkill = FakeDatabase.Skills.FirstOrDefault(skill => skill.ID == id);

                if (existingSkill != null)
                {
                    existingSkill.Name = name;
                }

                return existingSkill;
            }

            // Rimuovere un Skill tramite ID
            public bool DeleteSkill(int id)
            {
                Skill existingSkill = FakeDatabase.Skills.FirstOrDefault(skill => skill.ID == id);

                if (existingSkill != null)
                {
                    // verificare se gli skill sono associati a dei developer e nel caso, non rimuovere
                    if (HasSkillDevelopers(id))
                    {
                        return false; 
                    }

                    FakeDatabase.Skills.Remove(existingSkill);
                    return true; 
                }

                return false; // Skill non trovato.
            }

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

            // verificare se il developer ha degli skill associati
            private bool HasDeveloperSkills(int developerId)
            {
                return FakeDatabase.DeveloperSkills.Any(ds => ds.DeveloperID == developerId);
            }

            // verificare se uno skill è associato a dei developer
            private bool HasSkillDevelopers(int skillId)
            {
                return FakeDatabase.DeveloperSkills.Any(ds => ds.SkillID == skillId);
            }

            // metodo che genera un ID unico per Developer, Skill, e DeveloperSkill
            private int GenerateDeveloperId()
            {
                return FakeDatabase.Developers.Count > 0
                    ? FakeDatabase.Developers.Max(dev => dev.ID) + 1
                    : 1;
            }

            private int GenerateSkillId()
            {
                return FakeDatabase.Skills.Count > 0
                    ? FakeDatabase.Skills.Max(skill => skill.ID) + 1
                    : 1;
            }

            private int GenerateDeveloperSkillId()
            {
                return FakeDatabase.DeveloperSkills.Count > 0
                    ? FakeDatabase.DeveloperSkills.Max(ds => ds.ID) + 1
                    : 1;
            }
        }

    }

