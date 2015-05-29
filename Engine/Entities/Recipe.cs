using System;
using System.Collections.Generic;

namespace Engine.Entities
{
    public class Recipe
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }
        public int MinimumLevel { get; private set; } 
        public List<Skill> RequiredSkills { get; private set; }
        public List<ItemAndQuantity> RequiredIngredients { get; private set; } 
        public List<ItemAndQuantity> ItemsCreated { get; private set; } 

        public Recipe(Guid id, string name, int minimumLevel)
        {
            ID = id;
            Name = name;
            MinimumLevel = minimumLevel;

            RequiredSkills = new List<Skill>();
            RequiredIngredients = new List<ItemAndQuantity>();
            ItemsCreated = new List<ItemAndQuantity>();
        }
    }
}
