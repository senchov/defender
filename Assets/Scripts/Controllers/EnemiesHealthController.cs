using UnityEngine;
using Assets.Scripts.Models;
using Assets.Scripts.View;
using System;

namespace Assets.Scripts.Controllers
{
    [CreateAssetMenu(fileName = "EnemiesHealthController", menuName = "ScriptableObject/Battle/EnemiesHealthController")]
    partial class EnemiesHealthController : ScriptableObject, IInitable
    {
        [Validate(typeof(IGameObjectEventEmmitter))] [SerializeField] private ScriptableObject TargetProvider;
        [Validate(typeof(IGameObjectEventEmmitter))] [SerializeField] private ScriptableObject EnemyHealthHolder;
        [Validate(typeof(IDamageProvider))] [SerializeField] private ScriptableObject DamageProvider;

        //call from main init unity event
        public void Init()
        {
            EnemyProviderGetter.Emmit += OnEnemyAdded;
            HitEventGetter.GameObjectStringEmmit += OnEnemyGetHit;

            EnemyHealthGetter.Emmit += OnEnemyDie;
        }

        private void OnEnemyGetHit(GameObject hitTarget, string projectileId)
        {
            int damage = DamageProviderGetter.GetDamage(projectileId);           
            EnemmyRecieveDamageGetter.SetDamage(hitTarget,damage);
        }

        private void OnEnemyDie(GameObject enemy)
        {
            TargetTransformHolderGetter.RemoveTarget(enemy.transform);
            IDieble dieble = enemy.GetComponent<IDieble>();
            dieble.Die();
        }

        private void OnEnemyAdded(GameObject enemy)
        {
            EnemyHealthAddableGetter.AddGameObject(enemy);
        }
    }
}
