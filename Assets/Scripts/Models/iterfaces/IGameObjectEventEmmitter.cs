using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public interface IGameObjectEventEmmitter
    {
        event Action<GameObject> Emmit;
    }
}
