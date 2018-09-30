using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    //TODO create filler class for balance with difficulty / sec, difficulty = damage + health
    [CreateAssetMenu(fileName = "SpawnConfig", menuName = "ScriptableObject/Spawn/SpawnConfig")]
    class SpawnConfig : ScriptableObject, ISpawnSettings
    {
        [SerializeField] private List<SpawnSettingsItem> SpawnItems;
       
        Queue<SpawnSettingsItem> ItemsQueue;

        public List<string> GetEntitiesToSpawn()
        {
            if (ItemsQueue == null || ItemsQueue.Count == 0)
            {
                ItemsQueue = new Queue<SpawnSettingsItem>();
                foreach (SpawnSettingsItem item in SpawnItems)
                {
                    ItemsQueue.Enqueue(item);
                }
            }

            return ItemsQueue.Dequeue().SpawnEntities;
        }

        public List<float> GetTimeToSpawn()
        {
            List<float> timeToSpawn = new List<float>();
            foreach (SpawnSettingsItem item in SpawnItems)
            {
                timeToSpawn.Add(item.SpawnTime);
            }

            return timeToSpawn;
        }
    }
}
