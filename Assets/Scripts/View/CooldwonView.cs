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
        [SerializeField] private UnityEvent OnSpawnQueueEnded;
        [SerializeField] private float DelayBetweenLevels = 20.0f;
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

            StopAllCoroutines();
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
                yield return new WaitForSeconds(DelayBetweenLevels);
                OnSpawnQueueEnded.Invoke();        
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
