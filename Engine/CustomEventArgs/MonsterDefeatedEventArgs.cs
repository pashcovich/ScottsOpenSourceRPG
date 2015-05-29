using System;
using System.Collections.Generic;
using Engine.Entities;

namespace Engine.CustomEventArgs
{
    public class MonsterDefeatedEventArgs : EventArgs
    {
        public Monster Details { get; private set; }
        public List<ItemAndQuantity> LootedItems { get; private set; } 

        public MonsterDefeatedEventArgs(Monster monsterDefeated, List<ItemAndQuantity> lootedItems)
        {
            Details = monsterDefeated;
            LootedItems = lootedItems;
        }
    }
}
