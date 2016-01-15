namespace Engine.Entities
{
    public class Player : LivingCreature
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }

        public Player(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        public static Player CreateRandomPlayer()
        {
            return new Player(
                RandomNumberGenerator.GetNumberBetween(3, 18),
                RandomNumberGenerator.GetNumberBetween(3, 18),
                RandomNumberGenerator.GetNumberBetween(3, 18),
                RandomNumberGenerator.GetNumberBetween(3, 18),
                RandomNumberGenerator.GetNumberBetween(3, 18),
                RandomNumberGenerator.GetNumberBetween(3, 18));
        }
    }
}
