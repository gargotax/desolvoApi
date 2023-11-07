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

        //modificare un developerSkill
        public DeveloperSkill UpdateDeveloperSkill(int id, DeveloperSkill developerSkill)
        {
            DeveloperSkill existingDeveloperSkill = FakeDatabase.DeveloperSkills.FirstOrDefault(ds => ds.ID == id);

                if (existingDeveloperSkill != null)
                {
                    // aggiornare i dati
                    existingDeveloperSkill.DeveloperID = developerSkill.ID;
                    existingDeveloperSkill.SkillID = developerSkill.ID;


                    return existingDeveloperSkill;
                }

                // torna null se l'id dato al developerskill non esiste
                return null;
            
        }

        // verificare se un developer ha degli skill associati
        public bool HasDeveloperSkills(int developerId)
        {
            foreach (var developerSkill in FakeDatabase.DeveloperSkills)
            {
                if (developerSkill.DeveloperID == developerId)
                {
                    return true;
                }
            }

            return false;
        }

        // verificare se un uno skill è associato a degli developer
        public bool HasSkillDevelopers(int skillId)
        {
            foreach (var developerSkill in FakeDatabase.DeveloperSkills)
            {
                if (developerSkill.SkillID == skillId)
                {
                    return true;
                }
            }

            return false;
        }


        // metodo che genera un id unico per developerskill
        private int GenerateDeveloperSkillId()
        {
            if (FakeDatabase.DeveloperSkills.Count > 0)
            {
                return FakeDatabase.DeveloperSkills.Max(ds => ds.ID) + 1;
            }
            else
            {
                return 1;
            }
        }

        // ottenere un DeveloperSkill tramite ID
        public DeveloperSkill GetDeveloperSkillById(int id)
        {
            foreach (var developerSkill in FakeDatabase.DeveloperSkills)
            {
                if (developerSkill.ID == id)
                {
                    return developerSkill;
                }
            }

            return null; // Restituiamo null se non viene trovato alcun DeveloperSkill con l'ID specificato.
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

        //assegnare uno skill
        public DeveloperSkill AssignSkill(int developerId, int skillId)
        {
            DeveloperSkill existingDeveloperSkill = FakeDatabase.DeveloperSkills.FirstOrDefault(ds => ds.DeveloperID == developerId && ds.SkillID == skillId);

            if (existingDeveloperSkill != null)
            {
                return existingDeveloperSkill;
            }

            // Crea un DeveloperSkill assignment
            DeveloperSkill newDeveloperSkill = new DeveloperSkill
            {
                ID = GenerateDeveloperSkillId(), // Generate a unique ID
                DeveloperID = developerId,
                SkillID = skillId
            };

            // lo aggiungo alla lista
            FakeDatabase.DeveloperSkills.Add(newDeveloperSkill);

            return newDeveloperSkill;
        }

        //rimuovere skill assegnato
        public bool DeleteAssignment(int developerId, int skillId)
        {
            DeveloperSkill developerSkillToDelete = FakeDatabase.DeveloperSkills.FirstOrDefault(ds => ds.DeveloperID == developerId && ds.SkillID == skillId);

            if (developerSkillToDelete != null)
            {
                FakeDatabase.DeveloperSkills.Remove(developerSkillToDelete);
                return true; 
            }

            return false; 
        }

    }

}
