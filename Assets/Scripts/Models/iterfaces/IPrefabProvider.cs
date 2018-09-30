using UnityEngine;

namespace Assets.Scripts.Models
{
    interface IPrefabProvider
    {
        GameObject GetPrefab(string prefab);
    }
}
