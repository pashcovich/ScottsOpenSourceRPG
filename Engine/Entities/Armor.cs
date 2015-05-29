using System;

namespace Engine.Entities
{
    public class Armor : BaseGameItem
    {
        public ArmorLocations ArmorLocation { get; private set; }

        internal Armor(Guid id, string name, string namePlural, ArmorLocations location)
            : base(id, name, namePlural)
        {
            ArmorLocation = location;
        }
    }
}
