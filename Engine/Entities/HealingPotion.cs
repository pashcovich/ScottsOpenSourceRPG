using System;

namespace Engine.Entities
{
    public class HealingPotion : Potion
    {
        private readonly int _amountToHeal;

        internal HealingPotion(Guid id, string name, string namePlural, int amountToHeal, int minimumLevelToUse = 0, int maximumStackSize = 0)
            : base(id, name, namePlural, minimumLevelToUse, maximumStackSize)
        {
            _amountToHeal = amountToHeal;
        }
    }
}
