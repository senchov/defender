using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public interface IGameObjectStringEmmitter
    {
        event Action<GameObject, string> GameObjectStringEmmit;
    }
}
