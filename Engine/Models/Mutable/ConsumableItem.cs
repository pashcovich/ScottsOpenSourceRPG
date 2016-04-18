namespace Engine.Models.Mutable
{
    public class ConsumableItem : GameItem
    {
        public ConsumableItem(string name, string namePlural, string description, 
            int price, int levelRequiredToUse = 0) 
            : base(name, namePlural, description, price, levelRequiredToUse)
        {
        }
    }
}
