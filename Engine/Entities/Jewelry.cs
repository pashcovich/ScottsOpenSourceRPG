using System;

namespace Engine.Entities
{
    public class Jewelry : BaseGameItem
    {
        public JeweleryLocations JewelryLocation { get; private set; }

        internal Jewelry(Guid id, string name, string namePlural, JeweleryLocations location)
            : base(id, name, namePlural)
        {
            JewelryLocation = location;
        }
    }
}
