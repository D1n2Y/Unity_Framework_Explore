using FrameworkDesign.CounterApp.Utility;
using UnityEditor;

namespace FrameworkDesign.CounterApp.Editor
{
    public class EditorPreferencesStorage : IStorage
    {
        void IStorage.SaveInt(string key, int value)
        {
            EditorPrefs.SetInt(key, value);
        }

        int IStorage.LoadInt(string key, int defaultValue)
        {
            return EditorPrefs.GetInt(key, defaultValue);
        }
    }
}
