using UnityEngine;

namespace Assets.Scripts.Models
{
    public interface IInRange
    {
        bool IsInRange(Transform position);
    }
}
