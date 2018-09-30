using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class DistanceToFortView : MonoBehaviour, ITargetSetter, IDistanceToTargetSetter
    {
        [SerializeField] private DistanceToTargetUnityEvent InitialEvent;
        [SerializeField] private UnityEvent ReachFort;

        private Vector3 FortPos;
        private float DistanceToTarget;

        private void Awake()
        {
            InitialEvent.Invoke(gameObject.tag, this, this);
        }

        public void SetMinDistanceToTarget(float minDistance)
        {
            DistanceToTarget = minDistance;
        }

        public void SetTarget(Vector3 target)
        {
            FortPos = target;           
        }

        private void Update()
        {
            float distanceToFort = FortPos.x - transform.position.x;
            if (distanceToFort < DistanceToTarget)
            {
                ReachFort.Invoke();
                this.enabled = false;
            }
        }
    }
}
