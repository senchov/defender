using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "EnemyHealthHolder", menuName = "ScriptableObject/Battle/EnemyHealthHolder")]
    class EnemyHealthHolder : ScriptableObject, IGameObjectAddeble, IGameObjectEventEmmitter, IInitable, ISetDamageByGameObject
    {
        [SerializeField] private IntByKey[] EnemyDefaultHealth;      

        public event Action<GameObject> Emmit;
        private void EmmitHandler(GameObject go)
        {
            if (Emmit != null)
                Emmit(go);
        }

        private Dictionary<GameObject, Health> HealthByGameObject;

        public void AddGameObject(GameObject go)
        {
            if (!HealthByGameObject.ContainsKey(go))
            {
                int health = GetHealth(go.tag);
                HealthByGameObject.Add(go, new Health(health));
            }
        }

        //call from main init unity event
        public void Init()
        {
            HealthByGameObject = new Dictionary<GameObject, Health>();
        }

        public void SetDamage(GameObject go, int damage)
        {           
            if (HealthByGameObject.ContainsKey(go))
            {
                HealthByGameObject[go].SetDamage(damage);                
                if (HealthByGameObject[go].IsDead)
                {                   
                    HealthByGameObject.Remove(go);
                    EmmitHandler(go);
                }
            }
        }

        private int GetHealth(string id)
        {
            if (IsKeyPresented(id))
            {
                return EnemyDefaultHealth.Where(x => x.Key == id).First().IntValue;
            }
            return 0;
        }

        private bool IsKeyPresented(string key)
        {
            return EnemyDefaultHealth.Select(x => x.Key).Contains(key);
        }

        private class Health : IDamageble
        {
            private int HealthAmount;

            public Health(int health)
            {
                HealthAmount = health;
            }

            public void SetDamage(int damage)
            {
                HealthAmount -= damage;
            }

            public bool IsDead
            {
                get
                {
                    return HealthAmount < 1;
                }
            }
        }
    }
}
