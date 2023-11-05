using Desolvo.Models;

namespace Desolvo.Data
{
    // qui ho creato una classe statica che funge da DB
        public static class FakeDatabase
        {
            public static List<Developer> Developers { get; } = new List<Developer>();
            public static List<Skill> Skills { get; } = new List<Skill>();
            public static List<DeveloperSkill> DeveloperSkills { get; } = new List<DeveloperSkill>();
        }
    
}
