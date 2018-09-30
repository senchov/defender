using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class MainInitializer : MonoBehaviour
    {
        [SerializeField] private UnityEvent Init;

        private void Start()
        {
            Init.Invoke();
        }
    }
}
