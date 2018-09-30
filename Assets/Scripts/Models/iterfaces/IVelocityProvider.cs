using UnityEngine;

namespace Assets.Scripts.Models
{
    interface IVelocityProvider
    {
        Vector3 GetVelocity(string entity);
    }
}
