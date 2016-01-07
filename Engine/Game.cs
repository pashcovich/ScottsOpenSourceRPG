using System;

namespace Engine
{
    public class Game
    {
        public string Name { get; private set; }
        public Version CurrentVersion { get; private set; }
        public int CopyrightYear { get; private set; }
        public string WebsiteURL { get; private set; }
        public string WebsiteName { get; private set; }

        public Game(string name, int major, int minor, int copyrightYear, string websiteURL, string websiteName)
        {
            Name = name;
            CurrentVersion = new Version(major, minor);
            CopyrightYear = copyrightYear;
            WebsiteURL = websiteURL;
            WebsiteName = websiteName;
        }
    }
}
