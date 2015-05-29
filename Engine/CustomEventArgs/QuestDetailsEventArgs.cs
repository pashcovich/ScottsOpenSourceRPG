using System;
using Engine.Entities;

namespace Engine.CustomEventArgs
{
    public class QuestDetailsEventArgs : EventArgs
    {
        public Quest Details { get; private set; }

        public QuestDetailsEventArgs(Quest quest)
        {
            Details = quest;
        }
    }
}
