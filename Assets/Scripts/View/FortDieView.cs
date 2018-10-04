using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class FortDieView : MonoBehaviour, IDieble
    {
        [SerializeField] private UnityEvent OnFortDie;
        [SerializeField] private DiebleUnityEvent Subscribe;

        private void Awake()
        {
            Subscribe.Invoke(this);
        }

        public void Die()
        {
            OnFortDie.Invoke();
        }
    }
}
