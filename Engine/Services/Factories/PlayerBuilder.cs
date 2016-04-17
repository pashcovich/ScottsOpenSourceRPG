using Engine.Models.Mutable;

namespace Engine.Services.Factories
{
    public static class PlayerBuilder
    {
        public static Player CreateNew(string name)
        {
            return new Player(name);
        }
    }
}
