using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    //TODO create filler class for balance with difficulty / sec, difficulty = damage + health
    [CreateAssetMenu(fileName = "SpawnSettings", menuName = "ScriptableObject/Spawn/SpawnSettings")]
    class SpawnSettings : ScriptableObject, ISpawnSettings
    {
        [SerializeField] private List<SpawnSettingsItem> SpawnItems;
        [Validate(typeof(ISpawnPointModel))] [SerializeField] private ScriptableObject SpawnPointsModel;

        public List<float> GetTimeToSpawn()
        {
            List<float> timeToSpawn = new List<float>();
            return timeToSpawn;
        }
    }
}
