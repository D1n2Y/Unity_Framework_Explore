using UnityEngine;

namespace FrameworkDesign.CounterApp.Utility
{
    public class PlayerPreferencesStorage : IStorage
    {
        void IStorage.SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

        int IStorage.LoadInt(string key, int defaultValue)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
    }
}
