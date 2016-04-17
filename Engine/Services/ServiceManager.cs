using Engine.Services.Interfaces;
using Engine.Services.Providers;

namespace Engine.Services
{
    public static class ServiceManager
    {
        public static IRandomNumberGenerator RandomNumberService { get; private set; }

        static ServiceManager()
        {
            RandomNumberService = new RandomNumberGenerator();
        }

        public static void ReplaceRandomNumberGeneratorWith(IRandomNumberGenerator randomNumberGenerator)
        {
            RandomNumberService = randomNumberGenerator;
        }
    }
}
