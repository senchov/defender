using UnityEngine;

namespace Assets.Scripts.View
{
    public interface IProjectileMover
    {
        void Move(float time, Vector3 start, Vector3 controll, Vector3 end);
    }
}
