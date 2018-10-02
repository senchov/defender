using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class ArcherAtackView : MonoBehaviour, IAtackable, IShootable
    {
        [SerializeField] private Events InnerEvents;
        [SerializeField] private Transform SpawnPoint;
        [SerializeField] private ShootDuration Duration;
        //TODO remove, refactor IAtackeble
        public event Action<string> OnAtack;

        public void Atack()
        {
            InnerEvents.TryShoot.Invoke(this);
        }

        public void Shoot(Vector3 target, GameObject prefab)
        {
            InnerEvents.Shoot.Invoke();
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = SpawnPoint.position;
            CreateProjectile(target, projectile);
        }

        private void CreateProjectile(Vector3 target, GameObject projectile)
        {
            IProjectileMover mover = projectile.GetComponent<IProjectileMover>();
            float shootDuration = Duration.GetShootDuration();
            Vector3 start = SpawnPoint.transform.position;
            Vector3 end = target;
            Vector3 controll = GetControllPoint(start, end);
            mover.Move(shootDuration, start, controll, end);
        }

        private Vector3 GetControllPoint(Vector3 start, Vector3 end)
        {
            Vector2 dir = end - start;
            dir *= 0.5f;
            dir = Quaternion.Euler(0, 0, -45.0f) * dir;
            return new Vector3(dir.x, dir.y, 0) + start;
        }

        [Serializable]
        private class Events
        {
            public ShootebleUnityEvent TryShoot;
            public UnityEvent Shoot;
            public GameObjectUnityEvent SpawnProjectile;
        }

        [Serializable]
        private class ShootDuration
        {
            [SerializeField] private float Max = 2;
            [SerializeField] private float Min = 1;

            public float GetShootDuration()
            {
                return UnityEngine.Random.Range(Min, Max);
            }
        }
    }
}
