using FrameworkDesign.Example.Model;
using UnityEngine;

namespace FrameworkDesign.Example.Game
{
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Destroy(gameObject);
            ++GameModel.ClickedCnt;
        }
    }
}
