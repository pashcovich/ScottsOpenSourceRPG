namespace Engine.Services.Interfaces
{
    public interface IRandomNumberGenerator
    {
        int GetNumberBetween(int minimumValue, int maximumValue);
    }
}
