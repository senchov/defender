using Assets.Scripts.Models;
using UnityEngine;
using Assets.Scripts.View;

namespace Assets.Scripts.Controllers
{
    [CreateAssetMenu(fileName = "ShootArchersController", menuName = "ScriptableObject/Battle/ShootArchersController")]
    partial class ShootArchersController : ScriptableObject
    {
        [Validate(typeof(ITargetProvider))] [SerializeField] private ScriptableObject TargetProvider;
        [Validate(typeof(IPrefabProvider))] [SerializeField] private ScriptableObject PrefabProvider;
        [SerializeField] private string Arrow = "Arrow";

        //call from main init unity event
        public void Init()
        {
            TargetProviderInitGetter.Init();
        }

        public void AddTarget(Transform target)
        {           
            TransformListGetter.AddTarget(target);
        }

        public void ArcherAtack(IShootable shootable)
        {
            if (TargetProviderGetter.HasTarget)
            {
                shootable.Shoot(TargetProviderGetter.GetTarget(), PrefabProvideGetter.GetPrefab(Arrow));
            }
        }
    }
}
