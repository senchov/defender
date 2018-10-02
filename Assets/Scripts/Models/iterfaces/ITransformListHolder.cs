using UnityEngine;

namespace Assets.Scripts.Models
{
    interface ITransformListHolder
    {
        void AddTarget(Transform target);
        void RemoveTarget(Transform target);
    }
}
