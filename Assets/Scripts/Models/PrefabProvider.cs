using UnityEngine;
using System;
using System.Linq;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "PrefabProvider", menuName = "ScriptableObject/Spawn/PrefabProvider")]
    class PrefabProvider : ScriptableObject, IPrefabProvider
    {
        [SerializeField] private PrefabByKey[] Prefabs;

        //TODO object pool
        public GameObject GetPrefab(string prefabKey)
        {
            if (IsKeyPresented(prefabKey))
            {
                return Prefabs.Where(x => x.Key == prefabKey).Select(y => y.Prefab).First();
            }

            return null;
        }

        private bool IsKeyPresented(string prefabKey)
        {
            return Prefabs.Select(x => x.Key).Contains(prefabKey);
        }

        [Serializable]
        private class PrefabByKey
        {
            public string Key;
            public GameObject Prefab;
        }
    }
}
