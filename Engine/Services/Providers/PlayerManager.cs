using System;
using Engine.Models.Mutable;
using Engine.Services.Interfaces;

namespace Engine.Services.Providers
{
    public class PlayerManager : IPersistenceManager<Player>
    {
        public Player LoadByID(Guid id)
        {
            // Get data from persistence source

            // Pass to Player constructor that accepts the datarow (?)

            return new Player("");
        }

        public void Save(Player entity)
        {
            // Save to persistence source
        }
    }
}
