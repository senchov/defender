using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "TargetProvider", menuName = "ScriptableObject/Battle/TargetProvider")]
    class TargetProvider : ScriptableObject, ITargetProvider, IInitable
    {
        private List<Transform> Targets;

        public void Init()
        {
            Targets = new List<Transform>();
        }

        public void AddTarget(Transform target)
        {
            Targets.Add(target);
        }

        public void RemoveTarget(Transform target)
        {
            Targets.Remove(target);
        }

        public Vector3 GetTarget()
        {
            int targetIndex = Random.Range(0,Targets.Count);
            return Targets[targetIndex].position;
        }

        private void OnDisable()
        {
            Targets = new List<Transform>();
        }
    }
}
