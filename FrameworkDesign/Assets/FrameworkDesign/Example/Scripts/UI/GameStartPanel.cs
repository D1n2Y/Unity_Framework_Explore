using FrameworkDesign.Example.Event;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example.UI
{
    public class GameStartPanel : MonoBehaviour
    {
        private Button _btnStart;

        private void Awake()
        {
            if (this.transform.Find("Btn_Start") is Transform start)
            {
                _btnStart = start.GetComponent<Button>();
            }
        }

        private void Start()
        {
            if (_btnStart)
            {
                _btnStart.onClick.AddListener(OnStartClick);
            }
        }

        private void OnStartClick()
        {
            gameObject.SetActive(false);
            GameEvent.Trigger(Event.Event.GameStart);
        }
    }
}
