using System;

namespace Engine.Entities
{
    public abstract class Potion : ConsumableItem
    {
        internal Potion(Guid id, string name, string namePlural)
            : base(id, name, namePlural)
        {
        }
    }
}
