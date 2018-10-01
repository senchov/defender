using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "DistanceToFortProvider", menuName = "ScriptableObject/Movement/DistanceToFortProvider")]
    class DistanceToFortProvider : ScriptableObject, IDistanceToFortProvider
    {
        [SerializeField] private DistancesByKey[] Distances;

        public float GetMinDistanceToFort(string id)
        {
            if (IsKeyPresented(id))
            {
                return Distances.Where(x => x.Key == id).First().MinDistanceToFort;
            }
            return 0;
        }

        public float GetMinDistanceToGetDamage(string id)
        {
            if (IsKeyPresented(id))
            {
                return Distances.Where(x => x.Key == id).First().MinDistanceToGetDamage;
            }
            return 0;
        }

        private bool IsKeyPresented(string prefabKey)
        {
            return Distances.Select(x => x.Key).Contains(prefabKey);
        }        
    }

    [Serializable]
    public class DistancesByKey
    {
        public string Key;
        public float MinDistanceToFort;
        public float MinDistanceToGetDamage;
    }
}
