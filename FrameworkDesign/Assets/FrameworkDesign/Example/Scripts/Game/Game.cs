using System;
using FrameworkDesign.Example.Event;
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
            if (_goEnemies)
            {
                _goEnemies.SetActive(true);
            }
        }
    }
}