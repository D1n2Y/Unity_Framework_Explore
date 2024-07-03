using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using FrameworkDesign.CounterApp.Command;
using FrameworkDesign.CounterApp.IoC;
using FrameworkDesign.CounterApp.Model;
using FrameworkDesign.CounterApp.Utility;

namespace FrameworkDesign.CounterApp.Editor
{
    public class CounterApp : EditorWindow
    {
        private Label _lblCount;

        [SerializeField] private VisualTreeAsset _asset;

        [MenuItem("Window/CounterApp")]
        private static void Open()
        {
            App.Container.RegisterSingleton<IStorage, EditorPreferencesStorage>();
            App.Container.RegisterSingleton<CounterModel, CounterModel>();
            GetWindow<CounterApp>();
        }

        public void CreateGUI()
        {
            if (_asset)
            {
                _asset.CloneTree(rootVisualElement);
            }

            _lblCount = rootVisualElement.Q<Label>();
            rootVisualElement.Q<Button>(className: "Add").clicked += ClickedAdd;
            rootVisualElement.Q<Button>(className: "Sub").clicked += ClickedSub;
            ChangeCount();
        }

        private void ClickedAdd()
        {
            new CounterAdd().Execute();
            ChangeCount();
        }

        private void ClickedSub()
        {
            new CounterSub().Execute();
            ChangeCount();
        }

        private void ChangeCount()
        {
            _lblCount.text = App.Container.Resolve<CounterModel>().BindableCount.Value.ToString();
        }
    }
}
