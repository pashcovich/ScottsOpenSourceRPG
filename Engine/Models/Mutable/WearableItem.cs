namespace Engine.Models.Mutable
{
    public abstract class WearableItem : GameItem
    {
        public enum WearableOn
        {
            Head,
            LeftEar,
            RightEar,
            Neck,
            LeftShoulder,
            RightShoulder,
            Back,
            Chest,
            LeftArm,
            RightArm,
            LeftWrist,
            RightWrist,
            LeftHand,
            RightHand,
            Waist,
            Legs,
            LeftFoot,
            RightFoot
        }

        public WearableOn CanBeWornOn { get; private set; }

        protected WearableItem(string name, string namePlural, string description, 
            WearableOn canBeWornOn, int price, int levelRequiredToUse = 0) 
            : base(name, namePlural, description, price, levelRequiredToUse)
        {
            CanBeWornOn = canBeWornOn;
        }
    }
}
