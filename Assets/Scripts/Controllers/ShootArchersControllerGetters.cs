using Assets.Scripts.Models;

namespace Assets.Scripts.Controllers
{
    partial class ShootArchersController
    {
        private ITargetProvider _TargetProvider;
        private ITargetProvider TargetProviderGetter
        {
            get
            {
                if (_TargetProvider == null)
                    _TargetProvider = TargetProvider as ITargetProvider;
                return _TargetProvider;
            }
        }

        private IInitable _Initable;
        private IInitable TargetProviderInitGetter
        {
            get
            {
                if (_Initable == null)
                    _Initable = TargetProvider as IInitable;
                return _Initable;
            }
        }

        private ITransformListHolder _TransformListHolder;
        private ITransformListHolder TransformListGetter
        {
            get
            {
                if (_TransformListHolder == null)
                    _TransformListHolder = TargetProvider as ITransformListHolder;
                return _TransformListHolder;
            }
        }

        private IPrefabProvider _PrefabProvide;
        private IPrefabProvider PrefabProvideGetter
        {
            get
            {
                if (_PrefabProvide == null)
                    _PrefabProvide = PrefabProvider as IPrefabProvider;
                return _PrefabProvide;
            }
        }
    }
}
