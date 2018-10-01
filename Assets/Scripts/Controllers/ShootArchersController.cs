using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    [CreateAssetMenu(fileName = "ShootArchersController", menuName = "ScriptableObject/Battle/ShootArchersController")]
    partial class ShootArchersController : ScriptableObject
    {
        [Validate(typeof(ITargetProvider))] [SerializeField] private ScriptableObject TargetProvider;

        //call from main init unity event
        public void Init()
        {
            TargetProviderInitGetter.Init();
        }

        public void AddTarget(Transform target)
        {
            TargetProviderGetter.AddTarget(target);
        }
    }
}
