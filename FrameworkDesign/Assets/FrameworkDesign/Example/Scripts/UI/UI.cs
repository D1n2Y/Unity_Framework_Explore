using System;
using UnityEngine;
using FrameworkDesign.Example.Event;

namespace FrameworkDesign.Example.UI
{
    public class UI : MonoBehaviour
    {
        private GameObject _goPass;

        private void Awake()
        {
            RegisterGameEvent();

            FindChildren();
        }

        private void Start()
        {
            _goPass.SetActive(false);
        }

        private void OnDestroy()
        {
            UnregisterGameEvent();
        }

        private void RegisterGameEvent()
        {
            GameEvent.EventManager.Register(Event.Event.GamePass, ActiveGamePass);
        }

        private void UnregisterGameEvent()
        {
            GameEvent.EventManager.Unregister(Event.Event.GamePass, ActiveGamePass);
        }

        private void FindChildren()
        {
            if (transform.Find("Canvas/Pnl_GamePass") is Transform pass)
            {
                _goPass = pass.gameObject;
            }
        }

        private void ActiveGamePass(object _1, EventArgs _2)
        {
            if (_goPass)
            {
                _goPass.SetActive(true);
            }
        }
    }
}
