using System.Collections.Generic;

using Engine;

namespace ScottsOpenSourceRPG
{
    public static class KeyPressManager
    {
        private static readonly SortedDictionary<string, PlayerActions> _keyBindings = new SortedDictionary<string, PlayerActions>();

        static KeyPressManager()
        {
            PopulateKeyBindings();
        }

        public static PlayerActions GetPlayerAction(string key)
        {
            return _keyBindings.ContainsKey(key) ? _keyBindings[key] : PlayerActions.DoNothing;
        }

        private static void PopulateKeyBindings()
        {
            // TODO: Load from disk and add ability for player to modify and save to disk
            UpdateKeyBinding("W", PlayerActions.MoveNorth);
            UpdateKeyBinding("S", PlayerActions.MoveSouth);
            UpdateKeyBinding("D", PlayerActions.MoveEast);
            UpdateKeyBinding("A", PlayerActions.MoveWest);

            UpdateKeyBinding("Up", PlayerActions.MoveNorth);
            UpdateKeyBinding("Down", PlayerActions.MoveSouth);
            UpdateKeyBinding("Right", PlayerActions.MoveEast);
            UpdateKeyBinding("Left", PlayerActions.MoveWest);

            UpdateKeyBinding("F", PlayerActions.UseSelectedWeapon);
            UpdateKeyBinding("C", PlayerActions.UseSelectedConsumableItem);

            UpdateKeyBinding("I", PlayerActions.ViewInventory);
            UpdateKeyBinding("Q", PlayerActions.ViewQuestLog);
            UpdateKeyBinding("K", PlayerActions.ViewSkills);
        }

        private static void UpdateKeyBinding(string key, PlayerActions playerAction)
        {
            if(_keyBindings.ContainsKey(key))
            {
                _keyBindings[key] = playerAction;
            }
            else
            {
                _keyBindings.Add(key, playerAction);
            }
        }
    }
}
