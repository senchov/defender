using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.View
{
    public interface IDistanceToTargetSetter
    {
        void SetMinDistanceToTarget(float minDistance);
        void SetMinDistanceToGetDamage(float minDistance);
    }
}
