using System;

namespace Engine.Entities
{
    public class Weapon : BaseGameItem
    {
        public int MinimumLevelRequired { get; private set; }
        public int MinimumDamage { get; private set; }
        public int MaximumDamage { get; private set; }

        public Weapon(Guid id, string name, string namePlural, int minimumLevelRequired, int minimumDamage, int maximumDamage)
            : base(id, name, namePlural)
        {
            MinimumLevelRequired = minimumLevelRequired;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }
    }
}
