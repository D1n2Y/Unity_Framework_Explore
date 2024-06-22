using FrameworkDesign.Example.Event;
using UnityEngine;

namespace FrameworkDesign.Example.Game
{
    public class Enemy : MonoBehaviour
    {
        private static int s_clickedCnt;

        private void OnMouseDown()
        {
            Destroy(gameObject);
            if (++s_clickedCnt == 10)
            {
                GameEvent.Trigger(Event.Event.GamePass);
            }
        }
    }
}