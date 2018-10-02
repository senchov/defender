using UnityEngine;
using Assets.Scripts.Models;
using System;

namespace Assets.Scripts.Controllers
{
    [CreateAssetMenu(fileName = "EnemiesHealthController", menuName = "ScriptableObject/Battle/EnemiesHealthController")]
    partial class EnemiesHealthController : ScriptableObject, IInitable
    {
        [Validate(typeof(IGameObjectEventEmmitter))] [SerializeField] private ScriptableObject TargetProvider;
        [Validate(typeof(IGameObjectEventEmmitter))] [SerializeField] private ScriptableObject EnemyHealthHolder; 

        //call from main init unity event
        public void Init()
        {
            TargetProviderGetter.Emmit += OnEnemyAdded;
            EnemyHealthGetter.Emmit += OnEnemyDie;
        }

        private void OnEnemyDie(GameObject enemy)
        {
            
        }

        private void OnEnemyAdded(GameObject enemy)
        {
           
        }
    }
}
