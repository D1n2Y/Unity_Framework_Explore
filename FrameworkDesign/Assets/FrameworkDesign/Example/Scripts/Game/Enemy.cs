using UnityEngine;
using FrameworkDesign.Example.Model;

namespace FrameworkDesign.Example.Game
{
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Destroy(gameObject);
            ++GameModel.BindableClickedCnt.Value;
        }
    }
}
