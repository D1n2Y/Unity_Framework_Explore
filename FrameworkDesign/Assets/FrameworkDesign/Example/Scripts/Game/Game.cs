using System;
using UnityEngine;
using FrameworkDesign.Example.Event;
using FrameworkDesign.Example.Model;

namespace FrameworkDesign.Example.Game
{
    public class Game : MonoBehaviour
    {
        private GameObject _goEnemies;

        private void Awake()
        {
            RegisterGameEvent();

            FindChildren();
        }

        private void Start()
        {
            _goEnemies.SetActive(false);
        }

        private void OnDestroy()
        {
            UnregisterGameEvent();
        }

        private void RegisterGameEvent()
        {
            GameEvent.EventManager.Register(Event.Event.GameStart, ActiveEnemies);
        }

        private void UnregisterGameEvent()
        {
            GameEvent.EventManager.Unregister(Event.Event.GameStart, ActiveEnemies);
        }

        private void FindChildren()
        {
            if (transform.Find("Enemies") is Transform enemies)
            {
                _goEnemies = enemies.gameObject;
            }
        }

        private void ActiveEnemies(object _1, EventArgs _2)
        {
            if (!_goEnemies)
            {
                return;
            }

            _goEnemies.SetActive(true);
            GameModel.BindableClickedCnt.ValueChanged += OnClickedCntChanged;
        }

        private static void OnClickedCntChanged(int value)
        {
            if (value < GameModel.GamePassClickedCnt)
            {
                return;
            }

            GameEvent.EventManager.Trigger(Event.Event.GamePass);
            GameModel.BindableClickedCnt.ValueChanged -= OnClickedCntChanged;
        }
    }
}
