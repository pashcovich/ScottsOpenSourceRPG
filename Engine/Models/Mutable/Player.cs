using System;
using DotNetToolBox;

namespace Engine.Models.Mutable
{
    public class Player : Entity
    {
        private const int MAXIMUM_HIT_POINTS_PER_LEVEL = 10;

        private string _name;
        private int _currentHitPoints;
        private int _experiencePoints;
        private int _gold;

        public string Name
        {
            get { return _name; }
            private set
            {
                if(value.IsNotEqualTo(_name))
                {
                    _name = value;

                    NotifyPropertyChanged(() => Name);
                }
            }
        }

        public int MaximumHitPoints
        {
            get { return (Level * MAXIMUM_HIT_POINTS_PER_LEVEL); }
        }

        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            private set
            {
                if(value.WithLimitsOf(0, MaximumHitPoints).IsNotEqualTo(_currentHitPoints))
                {
                    _currentHitPoints = value.WithLimitsOf(0, MaximumHitPoints);

                    NotifyPropertyChanged(() => CurrentHitPoints);
                    NotifyPropertyChanged(() => IsAlive);
                    NotifyPropertyChanged(() => IsDead);
                }
            }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                if(_experiencePoints.IsNotEqualTo(value.WithLowerLimitOf(0)))
                {
                    _experiencePoints = value.WithLowerLimitOf(0);

                    NotifyPropertyChanged(() => ExperiencePoints);
                    NotifyPropertyChanged(() => Level);
                    NotifyPropertyChanged(() => MaximumHitPoints);
                }
            }
        }

        public int Level
        {
            get { return ReferenceData.Levels.FloorValueFor(ExperiencePoints); }
        }

        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;

                NotifyPropertyChanged(() => Gold);
            }
        }

        public bool IsAlive
        {
            get { return CurrentHitPoints > 0; }
        }

        public bool IsDead
        {
            get { return CurrentHitPoints <= 0; }
        }

        internal Player(string name)
        {
            ID = Guid.NewGuid();

            Name = name;

            CurrentHitPoints = MaximumHitPoints;
        }

        public void ApplyHeal(int amountToHeal)
        {
            CurrentHitPoints += amountToHeal;
        }

        public void ApplyDamage(int amountOfDamage)
        {
            CurrentHitPoints -= amountOfDamage;
        }

        public void GiveExperiencePoints(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
        }

        public void GiveGold(int amount)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException("'amount' cannot be less than 0");
            }

            Gold += amount;
        }

        public void TakeGold(int amount)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException("'amount' cannot be less than 0");
            }

            if(amount > Gold)
            {
                throw new ArgumentOutOfRangeException(string.Format("Player has {0} gold. Cannot take {1} gold.", Gold, amount));
            }

            Gold -= amount;
        }
    }
}