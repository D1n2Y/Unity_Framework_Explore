using UnityEngine;
using FrameworkDesign.CounterApp.View;
using FrameworkDesign.CounterApp.Model;
using FrameworkDesign.CounterApp.Command;
using FrameworkDesign.CounterApp.IoC;

namespace FrameworkDesign.CounterApp.Presenter
{
    public class CounterPresenter : MonoBehaviour,
        ICounterPresenter
    {
        private ICounterView _view;

        public ICounterView View
        {
            get => _view = _view ?? GetComponent<CounterView>();
            set => _view = value;
        }

        private void Start()
        {
            ChangeCount();
        }

        private void OnEnable()
        {
            App.Container.Resolve<CounterModel>().BindableCount.ValueChanged += OnCountChanged;
        }

        private void OnDisable()
        {
            App.Container.Resolve<CounterModel>().BindableCount.ValueChanged -= OnCountChanged;
        }

        public void ClickedAdd()
        {
            new CounterAdd().Execute();
        }

        public void ClickedSub()
        {
            new CounterSub().Execute();
        }

        private void OnCountChanged(int _)
        {
            ChangeCount();
        }

        private void ChangeCount()
        {
            View.SetCount(App.Container.Resolve<CounterModel>().BindableCount.Value.ToString());
        }
    }
}
