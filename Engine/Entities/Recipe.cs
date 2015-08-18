using System;
using System.Collections.Generic;

namespace Engine.Entities
{
    public class Recipe
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }
        public int MinimumLevelToUse { get; private set; } 
        public List<Skill> RequiredSkills { get; private set; }
        public List<ItemAndQuantity> RequiredIngredients { get; private set; } 
        public List<ItemAndQuantity> ItemsCreated { get; private set; } 

        public Recipe(Guid id, string name, int minimumLevelToUse)
        {
            ID = id;
            Name = name;
            MinimumLevelToUse = minimumLevelToUse;

            RequiredSkills = new List<Skill>();
            RequiredIngredients = new List<ItemAndQuantity>();
            ItemsCreated = new List<ItemAndQuantity>();
        }
    }
}
