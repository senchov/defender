using UnityEngine;
using System;
using System.Linq;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "DamageProvider", menuName = "ScriptableObject/Battle/DamageProvider")]
    class DamageProvider : ScriptableObject, IDamageProvider
    {
        [SerializeField] private IntByKey[] Damages;

        public int GetDamage(string id)
        {
            if (IsKeyPresented(id))
            {
                return Damages.Where(x => x.Key == id).First().IntValue;
            }
            return 0;
        }       

        private bool IsKeyPresented(string key)
        {
            return Damages.Select(x => x.Key).Contains(key);
        }

        [Serializable]
        private class IntByKey
        {
            public string Key;
            public int IntValue;
        }
    }
}
