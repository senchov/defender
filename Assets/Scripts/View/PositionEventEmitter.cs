using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class PositionEventEmitter : MonoBehaviour
    {
        [SerializeField] private Vector3UnityEvent PositionEmmit;

        private void Awake()
        {
            PositionEmmit.Invoke(transform.position);
        }
    }
}
