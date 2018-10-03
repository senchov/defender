using Assets.Scripts.Models;

namespace Assets.Scripts.Controllers
{
    partial class EnemiesHealthController
    {
        private IGameObjectEventEmmitter _Emitter;
        private IGameObjectEventEmmitter EnemyProviderGetter
        {
            get
            {
                if (_Emitter == null)
                    _Emitter = TargetProvider as IGameObjectEventEmmitter;
                return _Emitter;
            }
        }

        private ITransformListHolder _TargetProvider;
        private ITransformListHolder TargetTransformHolderGetter
        {
            get
            {
                if (_TargetProvider == null)
                    _TargetProvider = TargetProvider as ITransformListHolder;
                return _TargetProvider;
            }
        }

        private IGameObjectStringEmmitter _GameObjectStringEmitter;
        private IGameObjectStringEmmitter HitEventGetter
        {
            get
            {
                if (_GameObjectStringEmitter == null)
                    _GameObjectStringEmitter = TargetProvider as IGameObjectStringEmmitter;
                return _GameObjectStringEmitter;
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

        private IGameObjectAddeble _GOAddable;
        private IGameObjectAddeble EnemyHealthAddableGetter
        {
            get
            {
                if (_GOAddable == null)
                    _GOAddable = EnemyHealthHolder as IGameObjectAddeble;
                return _GOAddable;
            }
        }

        private ISetDamageByGameObject _SetDamageByGo;
        private ISetDamageByGameObject EnemmyRecieveDamageGetter
        {
            get
            {
                if (_SetDamageByGo == null)
                    _SetDamageByGo = EnemyHealthHolder as ISetDamageByGameObject;
                return _SetDamageByGo;
            }
        }

        private IDamageProvider _DamageProvider;
        private IDamageProvider DamageProviderGetter
        {
            get
            {
                if (_DamageProvider == null)
                    _DamageProvider = DamageProvider as IDamageProvider;
                return _DamageProvider;
            }
        }
    }
}
