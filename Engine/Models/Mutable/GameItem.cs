namespace Engine.Models.Mutable
{
    public abstract class GameItem
    {
        public string Name { get; private set; }
        public string NamePlural { get; private set; }
        public string Description { get; private set; }
        public int Price { get; private set; }
        public int LevelRequiredToUse { get; private set; }

        public GameItem(string name, string namePlural, string description, 
            int price, int levelRequiredToUse = 0)
        {
            Name = name;
            NamePlural = namePlural;
            Description = description;
            Price = price;
            LevelRequiredToUse = levelRequiredToUse;
        }
    }
}
