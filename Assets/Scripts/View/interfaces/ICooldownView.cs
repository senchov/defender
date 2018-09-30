using System;
using System.Collections.Generic;

namespace Assets.Scripts.View
{
    public interface ICooldownView
    {
        event Action Cooldown;
        void StartTimer(List<float> cooldowns);
    }
}
