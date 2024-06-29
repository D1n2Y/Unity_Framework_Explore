using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign.CounterApp.Presenter;

namespace FrameworkDesign.CounterApp.View
{
    public class CounterView : MonoBehaviour,
        ICounterView
    {
        private ICounterPresenter _presenter;
        private Button _btnAdd;
        private Button _btnSub;
        private Text _txtCount;

        public ICounterPresenter Presenter
        {
            get => _presenter = _presenter ?? GetComponent<CounterPresenter>();
            set => _presenter = value;
        }

        private void Awake()
        {
            _btnAdd = transform.Find("Btn_Add")?.GetComponent<Button>();
            _btnSub = transform.Find("Btn_Sub")?.GetComponent<Button>();
            _txtCount = transform.Find("Txt_Cnt")?.GetComponent<Text>();
        }

        private void OnEnable()
        {
            _btnAdd?.onClick.AddListener(OnAddClick);
            _btnSub?.onClick.AddListener(OnSubClick);
        }

        private void OnDisable()
        {
            _btnAdd?.onClick.RemoveListener(OnAddClick);
            _btnSub?.onClick.RemoveListener(OnSubClick);
        }

        public void SetCount(string text)
        {
            if (_txtCount)
            {
                _txtCount.text = text;
            }
        }

        private void OnAddClick()
        {
            Presenter.ClickedAdd();
        }

        private void OnSubClick()
        {
            Presenter.ClickedSub();
        }
    }
}
