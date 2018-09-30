using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class AtackView : MonoBehaviour, IAtackable
    {
        [SerializeField] private AtackebleUnityEvent InitialEvent;

        private void Awake()
        {
            InitialEvent.Invoke(this);
        }

        public event Action<string> OnAtack;

        private void OnAtackHandler()
        {
            if (OnAtack != null)
            {
                OnAtack(gameObject.tag);
            }
        }

        public void Atack()
        {
            OnAtackHandler();
        }        
    }
}
