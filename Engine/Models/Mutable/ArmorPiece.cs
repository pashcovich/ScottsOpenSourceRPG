namespace Engine.Models.Mutable
{
    public class ArmorPiece : WearableItem
    {
        public ArmorPiece(string name, string namePlural, string description,
            WearableOn canBeWornOn, int price, int levelRequiredToUse = 0) 
            : base(name, namePlural, description, canBeWornOn, price, levelRequiredToUse)
        {
        }
    }
}
