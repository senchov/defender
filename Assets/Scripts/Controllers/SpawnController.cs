using Assets.Scripts.Models;
using UnityEngine;
using Assets.Scripts.View;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Controllers
{
    [CreateAssetMenu(fileName = "SpawnController", menuName = "ScriptableObject/Spawn/SpawnController")]
    partial class SpawnController : ScriptableObject
    {
        [Validate(typeof(ISpawnSettings))] [SerializeField] private List<ScriptableObject> SpawnSettings;
        [Validate(typeof(IPrefabProvider))] [SerializeField] private ScriptableObject PrefabProvider;
        [Validate(typeof(ISpawnPointModel))] [SerializeField] private ScriptableObject SpawnPointProvider;

        private ICooldownView CooldownView;
        private ISpawnable SpawnView;
        private int Level;
        private List<ISpawnSettings> SettingsList;

        private void OnEnable()
        {
            FillSpawSettingList();
            Level = 0;
        }

        private void FillSpawSettingList()
        {
            SettingsList = new List<ISpawnSettings>();
            foreach (ScriptableObject spawnConfig in SpawnSettings)
            {
                SettingsList.Add(spawnConfig as ISpawnSettings);
            }
        }

        public void InitCooldownView(ICooldownView view)
        {
            CooldownView = view;
            CooldownView.Cooldown += OnCooldown;
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

        public void InitSpawnView(ISpawnable view)
        {
            SpawnView = view;
        }       

        public void Init()
        {          
            SpawnPointProviderGetter.FillSpawnPoints();
            CooldownView.StartTimer(SpawnSettingsGetter.GetTimeToSpawn());
        }        

        public void NewLevel()
        {
            Level = Mathf.Clamp(++Level, 0, SettingsList.Count - 1);          
            Init();
            Debug.LogError("new level started");
        }
    }
}
