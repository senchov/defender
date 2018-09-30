using Assets.Scripts.Models;
using UnityEngine;
using Assets.Scripts.View;
using System;

namespace Assets.Scripts.Controllers
{
    [CreateAssetMenu(fileName = "SpawnController", menuName = "ScriptableObject/Spawn/SpawnController")]
    partial class SpawnController : ScriptableObject
    {
        [Validate(typeof(ISpawnSettings))] [SerializeField] private ScriptableObject SpawnSettings;
        [Validate(typeof(IPrefabProvider))] [SerializeField] private ScriptableObject PrefabProvider;
        [Validate(typeof(ISpawnPointModel))] [SerializeField] private ScriptableObject SpawnPointProvider;

        private ICooldownView CooldownView;
        private ISpawnable SpawnView;

        public void InitCooldownView(ICooldownView view)
        {
            CooldownView = view;
            CooldownView.Cooldown += OnCooldown;
        }

        public void InitSpawnView(ISpawnable view)
        {
            SpawnView = view;
        }

        private void OnCooldown()
        {
            foreach (string entity in SpawnSettingsGetter.GetEntitiesToSpawn())
            {
                GameObject prefab = PrefabProvideGetter.GetPrefab(entity);
                Vector3 spawnPoint = SpawnPointProviderGetter.GetSpawnPoint();
                SpawnView.Spawn(prefab, spawnPoint);
            }
        }

        public void Init()
        {
            SpawnPointProviderGetter.FillSpawnPoints();
            CooldownView.StartTimer(SpawnSettingsGetter.GetTimeToSpawn());
        }
    }
}
