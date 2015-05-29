using System;

namespace Engine.Entities
{
    public abstract class ConsumableItem : BaseGameItem
    {
        internal ConsumableItem(Guid id, string name, string namePlural)
            : base(id, name, namePlural)
        {
        }
    }
}
