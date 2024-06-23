using System;
using FrameworkDesign.Example.Event;
using FrameworkDesign.Example.Model;
using UnityEngine;

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
            GameEvent.Register(Event.Event.GameStart, ActiveEnemies);
        }

        private void UnregisterGameEvent()
        {
            GameEvent.Unregister(Event.Event.GameStart, ActiveEnemies);
        }

        private void FindChildren()
        {
            if (transform.Find("Enemies") is Transform enemies)
            {
                _goEnemies = enemies.gameObject;
            }
        }

        private void ActiveEnemies(object _, EventArgs __)
        {
            if (!_goEnemies)
            {
                return;
            }

            _goEnemies.SetActive(true);
            GameModel.ClickedCntChanged += OnClickedCntChanged;
        }

        private static void OnClickedCntChanged()
        {
            if (GameModel.ClickedCnt < GameModel.GamePassClickedCnt)
            {
                return;
            }

            GameEvent.Trigger(Event.Event.GamePass);
            GameModel.ClickedCntChanged -= OnClickedCntChanged;
        }
    }
}
