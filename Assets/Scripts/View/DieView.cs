using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class DieView : MonoBehaviour, IDieble
    {       
        [SerializeField] private float DelayBeforeDestroy = 2.0f;
        [SerializeField] private SpriteRenderer Sprite;
        [SerializeField] private UnityEvent OnDie;

        public void Die()
        {
            OnDie.Invoke();
            StartCoroutine(Disappear());
        }

        private IEnumerator Disappear()
        {
            float time = 0;
            while (time < DelayBeforeDestroy)
            {
                time += Time.deltaTime;
                float value = 1 - time / DelayBeforeDestroy;
                Sprite.color = new Color(Sprite.color.r,Sprite.color.g,Sprite.color.b, value);
                yield return null;
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
