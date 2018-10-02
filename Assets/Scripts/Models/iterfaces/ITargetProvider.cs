using UnityEngine;

namespace Assets.Scripts.Models
{
    public interface ITargetProvider
    {       
        bool HasTarget { get; }
        Vector3 GetTarget();
    }
}
