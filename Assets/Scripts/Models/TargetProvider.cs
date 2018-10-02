using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "TargetProvider", menuName = "ScriptableObject/Battle/TargetProvider")]
    class TargetProvider : ScriptableObject, ITargetProvider, IInitable, ITransformListHolder, IInRange,
        IGameObjectEventEmmitter, IGameObjectStringEmmitter
    {
        [SerializeField] private float FuturePosPrediction;
        [SerializeField] private float InRangeSqrDistance;

        private List<Transform> Targets;

        public event Action<GameObject> Emmit;
        public event Action<GameObject, string> GameObjectStringEmmit;

        private void EmmitHandler(GameObject go)
        {
            if (Emmit != null)
                Emmit(go);
        }

        private void EmmitHitEventHandler(GameObject go, string projectileId)
        {
            if (GameObjectStringEmmit != null)
                GameObjectStringEmmit(go, projectileId);
        }

        public bool HasTarget
        {
            get
            {
                return Targets.Count > 0;
            }
        }

        public void Init()
        {
            Targets = new List<Transform>();
        }

        public void AddTarget(Transform target)
        {
            Targets.Add(target);
            EmmitHandler(target.gameObject);
        }

        public void RemoveTarget(Transform target)
        {
            Targets.Remove(target);
        }

        public Vector3 GetTarget()
        {
            int targetIndex = UnityEngine.Random.Range(0, Targets.Count);
            return Targets[targetIndex].position + new Vector3(FuturePosPrediction, 0, 0);
        }

        private void OnDisable()
        {
            Targets = new List<Transform>();
        }

        public bool IsInRange(Transform targetTransform)
        {
            for (int i = 0; i < Targets.Count; i++)
            {
                if (Vector3.SqrMagnitude(Targets[i].position - targetTransform.position) < InRangeSqrDistance)
                {
                    EmmitHitEventHandler(Targets[i].gameObject,targetTransform.tag);
                    Targets.Remove(Targets[i]);
                    return true;
                }
            }
            return false;
        }
    }
}
