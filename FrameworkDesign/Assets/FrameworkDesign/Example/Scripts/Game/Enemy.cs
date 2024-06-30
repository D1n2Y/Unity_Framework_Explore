using UnityEngine;
using FrameworkDesign.Example.Command;

namespace FrameworkDesign.Example.Game
{
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Destroy(gameObject);
            EnemyClicked.Exec();
        }
    }
}
