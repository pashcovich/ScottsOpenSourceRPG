using System;
using Engine.Entities;

namespace Engine.CustomEventArgs
{
    public class MonsterEncounteredEventArgs : EventArgs
    {
        public Monster CurrentMonster { get; private set; }

        public MonsterEncounteredEventArgs(Monster monster)
        {
            CurrentMonster = monster;
        }
    }
}
