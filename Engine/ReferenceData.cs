using System.Collections.Generic;
using System.Linq;
using DotNetToolBox.Collections;
using Engine.Models.Immutable;

namespace Engine
{
    public static class ReferenceData
    {
        public static SortedListWithFloorAndCeilingIntegerKey<int> Levels { get; } 
        public static List<Location> Locations { get; } 

        static ReferenceData()
        {
            Levels = new SortedListWithFloorAndCeilingIntegerKey<int>();
            PopulateLevels();

            Locations = new List<Location>();
        }

        private static void PopulateLevels()
        {
            Levels.AddListItem(0, 1);
            Levels.AddListItem(100, 2);
            Levels.AddListItem(250, 3);
            Levels.AddListItem(475, 4);
            Levels.AddListItem(813, 5);
        }

        public static void AddLocation(int xCoordinate, int yCoordinate, 
            string name, string description, 
            string terrainImageFile, string foregroundImageFile)
        {
            Location location = new Location(xCoordinate, yCoordinate, name, description, terrainImageFile, foregroundImageFile);

            if(!Locations.Any(loc => loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate))
            {
                Locations.Add(location);
            }
        }

        public static bool ThereIsLocationNorthOf(int xCoordinate, int yCoordinate)
        {
            return Locations.Exists(loc => loc.XCoordinate == xCoordinate && loc.YCoordinate == (yCoordinate + 1));
        }

        public static bool ThereIsLocationEastOf(int xCoordinate, int yCoordinate)
        {
            return Locations.Exists(loc => loc.XCoordinate == (xCoordinate + 1) && loc.YCoordinate == yCoordinate);
        }

        public static bool ThereIsLocationSouthOf(int xCoordinate, int yCoordinate)
        {
            return Locations.Exists(loc => loc.XCoordinate == xCoordinate && loc.YCoordinate == (yCoordinate - 1));
        }

        public static bool ThereIsLocationWestOf(int xCoordinate, int yCoordinate)
        {
            return Locations.Exists(loc => loc.XCoordinate == (xCoordinate - 1) && loc.YCoordinate == yCoordinate);
        }
    }
}
