using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign.Example.Event;

namespace FrameworkDesign.Example.UI
{
    public class GameStartPanel : MonoBehaviour
    {
        private Button _btnStart;

        private void Awake()
        {
            if (transform.Find("Btn_Start") is Transform start)
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
            GameEvent.EventManager.Trigger(Event.Event.GameStart);
        }
    }
}
