using System;

namespace Engine.Entities
{
    public class Skill
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }

        public int MinimumLevel { get; private set; }

        public Skill(Guid id, string name, int minimumLevel)
        {
            ID = id;
            Name = name;
            MinimumLevel = minimumLevel;
        }
    }
}
