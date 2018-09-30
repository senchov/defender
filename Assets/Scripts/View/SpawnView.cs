using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class SpawnView : MonoBehaviour, ISpawnable, ISpawnNotifier
    {
        [SerializeField] private SpawnableUnityEvent SubscribeSpawn;
        [SerializeField] private SpawnNotifierUnityEvent SubscribeSpawnNoify;

        public event Action<GameObject> SpawnNotify;

        private void Awake()
        {
            SubscribeSpawn.Invoke(this);
            SubscribeSpawnNoify.Invoke(this);
        }

        public void Spawn(GameObject prefab, Vector3 pos)
        {
            GameObject spawnEntity = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
            if (SpawnNotify != null)
            {
                SpawnNotify(spawnEntity);
            }
        }
    }
}
