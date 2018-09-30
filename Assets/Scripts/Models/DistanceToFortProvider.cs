using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "DistanceToFortProvider", menuName = "ScriptableObject/Movement/DistanceToFortProvider")]
    class DistanceToFortProvider : ScriptableObject, IDistanceToFortProvider
    {
        [SerializeField] private FloatByKey[] Distances;

        public float GetMinDistanceToFort(string id)
        {
            if (IsKeyPresented(id))
            {
                return Distances.Where(x => x.Key == id).First().FloatValue;
            }
            return 0;
        }

        private bool IsKeyPresented(string prefabKey)
        {
            return Distances.Select(x => x.Key).Contains(prefabKey);
        }        
    }

    [Serializable]
    public class FloatByKey
    {
        public string Key;
        public float FloatValue;
    }
}
