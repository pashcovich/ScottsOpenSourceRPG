using Engine.Models.Immutable;

namespace Engine.Models.Mutable
{
    public class Weapon : GameItem
    {
        public Weapon(string name, string namePlural, string description, 
            int price, int levelRequiredToUse = 0) 
            : base(name, namePlural, description, price, levelRequiredToUse)
        {
        }
    }
}
