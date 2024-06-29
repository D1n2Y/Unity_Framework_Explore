using UnityEngine;
using FrameworkDesign.CounterApp.Model;
using FrameworkDesign.CounterApp.View;

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
            CounterModel.BindableCount.ValueChanged += OnCountChanged;
        }

        private void OnDisable()
        {
            CounterModel.BindableCount.ValueChanged -= OnCountChanged;
        }

        public void ClickedAdd()
        {
            ++CounterModel.BindableCount.Value;
        }

        public void ClickedSub()
        {
            --CounterModel.BindableCount.Value;
        }

        private void OnCountChanged(int _)
        {
            ChangeCount();
        }

        private void ChangeCount()
        {
            View.SetCount(CounterModel.BindableCount.Value.ToString());
        }
    }
}
