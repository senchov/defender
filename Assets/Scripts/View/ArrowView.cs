using UnityEngine;
using UnityEngine.Events;
using Assets.Scripts.Models;

namespace Assets.Scripts.View
{
    class ArrowView : MonoBehaviour
    {
        [Validate(typeof(IInRange))] [SerializeField] private Object InRangeModel;

        private IInRange _InRangeProvide;
        private IInRange InRangeGetter
        {
            get
            {
                if (_InRangeProvide == null)
                    _InRangeProvide = InRangeModel as IInRange;
                return _InRangeProvide;
            }
        }

        public void Update()
        {
            if (InRangeGetter.IsInRange(transform))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
