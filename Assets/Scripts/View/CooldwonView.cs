using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class CooldwonView : MonoBehaviour, ICooldownView
    {
        [SerializeField] private CooldownViewUnityEvent Subscribe;
        public event Action Cooldown;
        private Queue<float> CooldownQueue = new Queue<float>();

        private void Awake()
        {
            Subscribe.Invoke(this);
        }

        public void StartTimer(List<float> cooldowns)
        {
            foreach (float cooldown in cooldowns)
            {
                CooldownQueue.Enqueue(cooldown);
            }

            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            if (CooldownQueue.Count > 0)
            {
                float cooldownTime = CooldownQueue.Dequeue();
                yield return new WaitForSeconds(cooldownTime);
                CooldownHandler();
                yield return StartCoroutine(Wait());
            }
            else
            {
                yield break;
            }
        }

        private void CooldownHandler()
        {
            if (Cooldown != null)
                Cooldown();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }        
    }
}
