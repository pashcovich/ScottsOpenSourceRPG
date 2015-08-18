using System;

namespace Engine.Entities
{
    public abstract class ConsumableItem : BaseGameItem
    {
        internal ConsumableItem(Guid id, string name, string namePlural, int minimumLevelToUse = 0, int maximumStackSize = 0)
            : base(id, name, namePlural, minimumLevelToUse, maximumStackSize)
        {
        }
    }
}
