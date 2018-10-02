using System;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "EnemyHealthHolder", menuName = "ScriptableObject/Battle/EnemyHealthHolder")]
    class EnemyHealthHolder : ScriptableObject, IGameObjectAddeble, IGameObjectEventEmmitter, IInitable, ISetDamageByGameObject
    {

        public event Action<GameObject> Emmit;
        private void EmmitHandler(GameObject go)
        {
            if (Emmit != null)
                Emmit(go);
        }

        public void AddGameObject(GameObject go)
        {

        }

        public void Init()
        {
            
        }

        public void SetDamage(GameObject obj, int damage)
        {
            
        }

        [Serializable]
        private class StartHealth
        {
            public int Bat = 150;
            public int Bomber = 100;
            public int Onager = 200;
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
                    return HealthAmount > 0;
                }
            }
        }
    }
}
