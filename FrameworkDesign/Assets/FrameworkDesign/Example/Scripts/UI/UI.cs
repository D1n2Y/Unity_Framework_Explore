using System;
using FrameworkDesign.Example.Event;
using UnityEngine;

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
            GameEvent.Register(Event.Event.GamePass, ActiveGamePass);
        }

        private void UnregisterGameEvent()
        {
            GameEvent.Unregister(Event.Event.GamePass, ActiveGamePass);
        }

        private void FindChildren()
        {
            if (transform.Find("Canvas/Pnl_GamePass") is Transform pass)
            {
                _goPass = pass.gameObject;
            }
        }

        private void ActiveGamePass(object _, EventArgs __)
        {
            if (_goPass)
            {
                _goPass.SetActive(true);
            }
        }
    }
}