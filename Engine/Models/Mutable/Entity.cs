using System;

namespace Engine.Models.Mutable
{
    public abstract class Entity : BaseModel
    {
        public Guid ID { get; protected set; }
    }
}
