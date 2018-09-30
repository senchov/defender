using System;
using UnityEngine;

namespace Assets.Scripts.View
{
    public interface ISpawnNotifier
    {
        event Action<GameObject> SpawnNotify;
    }
}
