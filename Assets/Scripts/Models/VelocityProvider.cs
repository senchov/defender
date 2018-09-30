using System.Linq;
using UnityEngine;
using System;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "VelocityProvider", menuName = "ScriptableObject/Movement/VelocityProvider")]
    class VelocityProvider : ScriptableObject, IVelocityProvider
    {
        [SerializeField] private VelocityItem[] Vectors;

        public Vector3 GetVelocity(string entity)
        {
            if (IsKeyPresented(entity))
            {
                return Vectors.Where(k => k.Key == entity).FirstOrDefault().GetVelocity();
            }

            return Vector3.zero;
        }

        private bool IsKeyPresented(string entity)
        {
            return Vectors.Select(x => x.Key).Contains(entity);
        }

        [Serializable]
        private class VelocityItem
        {
            public string Key;
            [SerializeField] private Vector3 Vector;
            [SerializeField] private float Speed;

            public Vector3 GetVelocity()
            {
                return Vector * Speed;
            }
        }
    }
}
