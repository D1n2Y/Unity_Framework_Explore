namespace FrameworkDesign.CounterApp.Utility
{
    public interface IStorage
    {
        void SaveInt(string key, int value);

        int LoadInt(string key, int defaultValue);
    }
}
