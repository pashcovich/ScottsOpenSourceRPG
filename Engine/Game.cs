using Engine.Entities;

namespace Engine
{
    public class Game
    {
        public World World { get; set; }
        public Player Player { get; set; }

        public Game() : this (new World(), new Player())
        {
        }

        public Game(World world, Player player)
        {
            World = world;
            Player = player;
        }
    }
}
