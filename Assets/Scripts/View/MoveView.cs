using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class MoveView : MonoBehaviour, IMoveble
    {
        [SerializeField] private MovebleViewStringUnityEvent Subscribe;
        [SerializeField] private MovebleViewUnityEvent StopMove;
        [SerializeField] private Transform Target;

        private Vector3 Velocity;

        private void Awake()
        {
            Subscribe.Invoke(this, gameObject.tag);
            if (Target == null)
                Target = transform;
        }

        private void Update()
        {
            Target.position += Velocity;
        }

        public void Move(Vector3 vel)
        {
            Velocity = vel;
        }

        //call from view unity event
        public void Stop()
        {
            StopMove.Invoke(this);
            this.enabled = false;
        }
    }
}
