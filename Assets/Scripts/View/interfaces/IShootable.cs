using UnityEngine;

namespace Assets.Scripts.View
{
    public interface IShootable
    {
        void Shoot(Vector3 target, GameObject projectile);
    }
}
