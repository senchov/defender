using UnityEngine;

namespace Assets.Scripts.View
{
    public interface ISpawnable
    {
        void Spawn(GameObject prefab, Vector3 pos);
    }
}
