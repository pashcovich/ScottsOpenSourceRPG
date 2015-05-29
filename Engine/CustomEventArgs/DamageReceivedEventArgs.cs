using System;

namespace Engine.CustomEventArgs
{
    public class DamageReceivedEventArgs : EventArgs
    {
        public int AmountOfDamage { get; private set; }

        public DamageReceivedEventArgs(int amountOfDamage)
        {
            AmountOfDamage = amountOfDamage;
        }
    }
}
