namespace Engine.Models.Immutable
{
    public class Location
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string TerrainImageFile { get; private set; }
        public string ForegroundImageFile { get; private set; }

        internal Location(int xCoordinate, int yCoordinate, 
            string name, string description, 
            string terrainImageFile, string foregroundImageFile)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            TerrainImageFile = terrainImageFile;
            ForegroundImageFile = foregroundImageFile;
        }
    }
}
