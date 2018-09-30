using UnityEngine;
using Assets.Scripts.Models;
using Assets.Scripts.View;

namespace Assets.Scripts.Controllers
{
    [CreateAssetMenu(fileName = "DistanceToFortController", menuName = "ScriptableObject/Movement/DistanceToFortController")]
    class DistanceToFortController : ScriptableObject
    {
        [Validate(typeof(IDistanceToFortProvider))] [SerializeField] private ScriptableObject DistanceProvider;

        private IDistanceToFortProvider _DistanceProvider;
        private IDistanceToFortProvider DistanceProviderGetter
        {
            get
            {
                if (_DistanceProvider == null)
                    _DistanceProvider = DistanceProvider as IDistanceToFortProvider;
                return _DistanceProvider;
            }
        }

        private Vector3 FortPos;

        public void SetFortPos(Vector3 pos)
        {
            FortPos = pos;
        }

        public void InitView(string id, ITargetSetter targetSetter, IDistanceToTargetSetter distanceSetter)
        {
            targetSetter.SetTarget(FortPos);
            float distance = DistanceProviderGetter.GetMinDistanceToFort(id);
            distanceSetter.SetMinDistanceToTarget(distance);
        }
    }
}
