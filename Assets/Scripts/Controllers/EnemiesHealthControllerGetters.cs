using Assets.Scripts.Models;

namespace Assets.Scripts.Controllers
{
    partial class EnemiesHealthController
    {
        private IGameObjectEventEmmitter _Emitter;
        private IGameObjectEventEmmitter TargetProviderGetter
        {
            get
            {
                if (_Emitter == null)
                    _Emitter = TargetProvider as IGameObjectEventEmmitter;
                return _Emitter;
            }
        }

        private IGameObjectEventEmmitter _EnemyHealth;
        private IGameObjectEventEmmitter EnemyHealthGetter
        {
            get
            {
                if (_EnemyHealth == null)
                    _EnemyHealth = EnemyHealthHolder as IGameObjectEventEmmitter;
                return _EnemyHealth;
            }
        }
    }
}
