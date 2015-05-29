using System.Collections.Generic;
using System.Linq;

using Engine.Collections;
using Engine.Entities;

namespace Engine
{
    public static class World
    {
        private static readonly SortedListWithFloorAndCeilingIntegerKey<int> _levels = new SortedListWithFloorAndCeilingIntegerKey<int>();

        private const int WORLD_SIZE = 29;
        private const int MIDPOINT = (WORLD_SIZE / 2);

        private static readonly List<Location> _locations = new List<Location>();

        static World()
        {
            PopulateLevelsList();
            PopulateLocationList();
        }

        public static int LevelForExperiencePoints(int experiencePoints)
        {
            return _levels.FloorValueFor(experiencePoints);
        }

        internal static Location LocationAtCoordinates(Coordinate coordinates)
        {
            return _locations.SingleOrDefault(loc => loc.Coordinates.Match(coordinates));
        }

        internal static Location StartingLocation()
        {
            return _locations.Single(loc => loc.Coordinates.Match(new Coordinate(MIDPOINT, MIDPOINT)));
        }

        private static void PopulateLevelsList()
        {
            _levels.Add(0, 1);
            _levels.Add(100, 2);
            _levels.Add(200, 3);
            _levels.Add(300, 4);
            _levels.Add(400, 5);
            _levels.Add(500, 6);
            _levels.Add(600, 7);
            _levels.Add(700, 8);
            _levels.Add(800, 9);
            _levels.Add(900, 10);
        }

        private static void PopulateLocationList()
        {
        }

        private static void UpdateLocationTo(Location newLocation)
        {
            _locations.RemoveAll(loc => loc.Coordinates.Match(newLocation.Coordinates));

            _locations.Add(newLocation);
        }
    }
}
