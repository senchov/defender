using UnityEngine;
using Assets.Scripts.Models;
using Assets.Scripts.View;

namespace Assets.Scripts.Controllers
{
    [CreateAssetMenu(fileName = "MoveController", menuName = "ScriptableObject/Movement/MoveController")]
    class MoveController : ScriptableObject
    {
        [Validate(typeof(IVelocityProvider))] [SerializeField] private ScriptableObject VelocityProvider;

        private IVelocityProvider _VelocityProvide;
        private IVelocityProvider VelocityProviderGetter
        {
            get
            {
                if (_VelocityProvide == null)
                    _VelocityProvide = VelocityProvider as IVelocityProvider;
                return _VelocityProvide;
            }
        }

        public void InitMovebleEntity(IMoveble moveble, string id)
        {           
            Vector3 vel = VelocityProviderGetter.GetVelocity(id);
            moveble.Move(vel);
        }

        public void StopMovebleEntity(IMoveble moveble)
        {           
            moveble.Move(Vector3.zero);
        }
    }
}
