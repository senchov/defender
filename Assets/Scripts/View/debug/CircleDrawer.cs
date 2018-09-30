using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View.debug
{
    class CircleDrawer : MonoBehaviour
    {
        public float Radius;

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}
