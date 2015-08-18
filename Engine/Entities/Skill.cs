using System;

namespace Engine.Entities
{
    public class Skill
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }

        public int MinimumLevelToUse { get; private set; }

        public Skill(Guid id, string name, int minimumLevelToUse)
        {
            ID = id;
            Name = name;
            MinimumLevelToUse = minimumLevelToUse;
        }
    }
}
