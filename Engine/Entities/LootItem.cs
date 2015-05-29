namespace Engine.Entities
{
    public class LootItem
    {
        public BaseGameItem Item { get; private set; }
        public int DropPercentage { get; private set; }
        public bool IsDefaultItem { get; private set; }

        internal LootItem(BaseGameItem item, int dropPercentage, bool isDefaultItem)
        {
            Item = item;
            DropPercentage = dropPercentage;
            IsDefaultItem = isDefaultItem;
        }
    }
}
