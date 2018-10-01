using UnityEngine;

namespace Assets.Scripts.Models
{
    public interface ITargetProvider
    {
        void AddTarget(Transform target);
        void RemoveTarget(Transform target);
        Vector3 GetTarget();
    }
}
