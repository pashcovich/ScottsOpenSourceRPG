using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

using Engine.CustomEventArgs;

namespace Engine.Entities
{
    public class Player : LivingCreature
    {
        #region Private variables

        private int _experiencePoints;
        private int _level;
        private Location _currentLocation;

        private readonly BindingList<ItemAndQuantity> _inventory = new BindingList<ItemAndQuantity>();
        private readonly BindingList<PlayerQuest> _playerQuests = new BindingList<PlayerQuest>();
        private readonly BindingList<Skill> _knownSkills = new BindingList<Skill>(); 
        private readonly BindingList<Recipe> _knownRecipes = new BindingList<Recipe>(); 

        #endregion

        #region Public EventHandlers

        public event EventHandler ExperiencePointsChanged;
        public event EventHandler LevelChanged;

        public event EventHandler<QuestDetailsEventArgs> QuestReceived;
        public event EventHandler<QuestDetailsEventArgs> QuestCompleted;
        public event EventHandler<MonsterEncounteredEventArgs> MonsterEncountered;
        public event EventHandler<DamageReceivedEventArgs> MonsterAttacked;
        public event EventHandler<MonsterDefeatedEventArgs> MonsterDefeated;

        #endregion

        #region Public properties

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            private set
            {
                _experiencePoints = value;

                UpdateExperiencePoints();
            }
        }
        
        public int Level
        {
            get { return _level; }
            private set
            {
                int priorLevel = _level;

                _level = value;

                if(_level != priorLevel)
                {
                    UpdateLevel();
                }
            }
        }

        public BindingList<ItemAndQuantity> Inventory
        {
            get { return _inventory; }
        }

        public ReadOnlyCollection<Weapon> Weapons
        {
            get { return _inventory.Where(x => x.Item is Weapon).Select(x => (Weapon)x.Item).OrderBy(x => x.Name).ToList().AsReadOnly(); }
        }

        public ReadOnlyCollection<ConsumableItem> ConsumableItems
        {
            get { return _inventory.Where(x => x.Item is Potion).Select(x => (ConsumableItem)x.Item).OrderBy(x => x.Name).ToList().AsReadOnly(); }
        }

        public bool HasWeapons
        {
            get { return (Weapons.Count > 0); }
        }

        public bool HasPotions
        {
            get { return (ConsumableItems.Count > 0); }
        }

        public BindingList<PlayerQuest> Quests
        {
            get { return _playerQuests; }
        }

        public BindingList<Skill> KnownSkills
        {
            get { return _knownSkills; }
        }

        public BindingList<Recipe> KnownRecipes
        {
            get {  return _knownRecipes; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            private set 
            { 
                _currentLocation = value;

                OnPropertyChanged("CurrentLocation");
            }
        }

        #endregion

        internal Player(int currentHitPoints, int experiencePoints)
        {
            ExperiencePointsChanged += UpdateLevel;
            LevelChanged += UpdateMaximumHitPoints;
            Killed += MoveHome;

            ExperiencePoints = experiencePoints;

            // TODO: Always make sure the player has at least a stick to fight with.
            //Weapon defaultWeapon = GameObjectFactory.Weapon.CreateWeapon(GameObjectFactory.Weapon.WeaponTypes.Stick);

            //AddInventoryItem(defaultWeapon);
            //CurrentWeapon = Weapons.First(weapon => weapon.Name == defaultWeapon.Name);

            // This needs to be done after setting the ExperiencePoints property value, 
            // since setting ExperiencePoints sets the Level, and Level limits the maximum CurrentHitPoint value
            CurrentHitPoints = currentHitPoints;
        }

        #region Public methods

        public void MoveToLocation(Location location)
        {
            // The World.MoveToLocation method returns a null if there is no location to move to.
            if(location == null)
            {
                return;
            }

            // Update the player's location with the new location
            CurrentLocation = location;

            // Get the monster living here, if there is one
            //CurrentMonster = location.MonsterEncounteredHere();

            // Get the quests the player has that can be completed here
            var potentiallyCompletableQuests =
                from pq in Quests
                join lq in location.AvailableQuests
                    on pq.Quest.Name equals lq.Name
                where !pq.IsCompleted
                select pq;

            // Check if the player has the required items in their inventory to complete a quest at this location
            foreach(PlayerQuest playerQuest in potentiallyCompletableQuests)
            {
                // Get a list of all inventory that have enough quantity to complete this quest
                var questCompletionItemsInPlayerInventory =
                    from playerInventory in Inventory
                    join questRequiredItems in playerQuest.Quest.ItemsNeededToComplete
                        on playerInventory.Item.Name equals questRequiredItems.Item.Name
                    where playerInventory.Quantity >= questRequiredItems.Quantity
                    select playerInventory;

                // If there is enough quantity for ALL items needed to complete the quest, then complete it
                if(questCompletionItemsInPlayerInventory.Count() == playerQuest.Quest.ItemsNeededToComplete.Count)
                {
                    foreach(ItemAndQuantity itemAndQuantity in playerQuest.Quest.ItemsNeededToComplete)
                    {
                        RemoveInventoryItem(itemAndQuantity.Item, itemAndQuantity.Quantity);
                    }

                    AddExperiencePoints(playerQuest.Quest.RewardExperiencePoints);
                    AddInventoryItems(playerQuest.Quest.RewardItems);

                    playerQuest.MarkAsCompleted();

                    QuestCompleted.SafeInvoke(new QuestDetailsEventArgs(playerQuest.Quest));
                }
            }

            // Add any quests available at this location
            // Do this AFTER completing existing quests, so the player will be able to receive repeatable quests
            foreach(Quest quest in location.AvailableQuests)
            {
                AddQuest(quest);
            }

            // Update the UI
            UpdateCurrentMonster(new MonsterEncounteredEventArgs(location.MonsterEncounteredHere()));
        }

        public void MoveNorth()
        {
            MoveToLocation(World.LocationAtCoordinates(CurrentLocation.Coordinates.CoordinatesToNorth()));
        }

        public void MoveSouth()
        {
            MoveToLocation(World.LocationAtCoordinates(CurrentLocation.Coordinates.CoordinatesToSouth()));
        }

        public void MoveEast()
        {
            MoveToLocation(World.LocationAtCoordinates(CurrentLocation.Coordinates.CoordinatesToEast()));
        }

        public void MoveWest()
        {
            MoveToLocation(World.LocationAtCoordinates(CurrentLocation.Coordinates.CoordinatesToWest()));
        }

        public void AttackCurrentMonster(Weapon weapon)
        {
            //CurrentMonster.ApplyDamage(RandomNumberGenerator.GetNumberBetween(weapon.MinimumDamage, weapon.MaximumDamage));

            //if(CurrentMonster.CurrentHitPoints <= 0)
            //{
            //    ReportMonsterKilled(CurrentMonster);
            //}
            //else
            //{
            //    ApplyDamage(RandomNumberGenerator.GetNumberBetween(0, CurrentMonster.MaximumDamage));
            //}
        }

        #endregion

        #region Private methods

        private void AddExperiencePoints(int experiencePointsToAdd)
        {
            ExperiencePoints += experiencePointsToAdd;
        }

        private void UpdateLevel(object sender, EventArgs e)
        {
            Level = World.LevelForExperiencePoints(ExperiencePoints);
        }

        private void UpdateMaximumHitPoints(object sender, EventArgs e)
        {
            MaximumHitPoints = (Level * 10);
        }

        private void AddQuest(Quest quest)
        {
            if(Quests.All(playerQuest => playerQuest.Quest.Name != quest.Name))
            {
                _playerQuests.Add(new PlayerQuest(quest));

                QuestReceived.SafeInvoke(new QuestDetailsEventArgs(quest));
            }
        }

        private void AddInventoryItem(BaseGameItem item, int quantity = 1)
        {
            ItemAndQuantity existingItem = Inventory.SingleOrDefault(x => x.Item.Name == item.Name);

            if(existingItem == null)
            {
                _inventory.Add(new ItemAndQuantity(item, quantity));
            }
            else
            {
                existingItem.Quantity++;

                Inventory.ResetBindings();
            }
        }

        private void AddInventoryItems(IEnumerable<ItemAndQuantity> items)
        {
            foreach(ItemAndQuantity itemAndQuantity in items)
            {
                AddInventoryItem(itemAndQuantity.Item, itemAndQuantity.Quantity);
            }
        }

        private void RemoveInventoryItem(BaseGameItem item, int quantity)
        {
            ItemAndQuantity existingItem = Inventory.SingleOrDefault(x => x.Item.Name == item.Name);

            if(existingItem != null)
            {
                if(existingItem.Quantity == quantity)
                {
                    Inventory.Remove(existingItem);
                }
                else
                {
                    existingItem.Quantity -= quantity;
                }
            }
        }

        private void ReportMonsterKilled(Monster monster)
        {
            AddExperiencePoints(monster.RewardExperiencePoints);

            List<ItemAndQuantity> lootedItems = monster.LootItems;
            AddInventoryItems(lootedItems);

            MonsterDefeated.SafeInvoke(new MonsterDefeatedEventArgs(monster, lootedItems));

            //CurrentMonster = null;
        }

        #endregion

        #region Methods to raise events

        protected virtual void UpdateExperiencePoints()
        {
            ExperiencePointsChanged.SafeInvoke();
            OnPropertyChanged("ExperiencePoints");
        }

        protected virtual void UpdateLevel()
        {
            LevelChanged.SafeInvoke();
            OnPropertyChanged("Level");

            CompletelyHeal();
        }

        protected virtual void UpdateCurrentMonster(MonsterEncounteredEventArgs e)
        {
            MonsterEncountered.SafeInvoke(e);
        }

        #endregion

        #region Methods to handle events

        private void MoveHome(object sender, EventArgs eventArgs)
        {
            MoveToLocation(World.StartingLocation());

            CompletelyHeal();
        }

        #endregion
    }
}
