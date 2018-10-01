using UnityEngine;
using UnityEngine.Events;
using System;
using Assets.Scripts.Models;
using System.Linq;

namespace Assets.Scripts.View
{
    class FortView : MonoBehaviour, IFortStateReceiver
    {
        [SerializeField] private SpriteRenderer FortSprite;
        [SerializeField] private SpriteByStates[] Sprites;
        [SerializeField] private FortStateReceiverUnityEvent InitialEvent;

        private void Awake()
        {
            InitialEvent.Invoke(this);
        }

        public void SetFortState(FortState state)
        {            
            FortSprite.sprite = GetSprite(state);
        }

        private Sprite GetSprite(FortState state)
        {
            return Sprites.Where(x => x.State == state).FirstOrDefault().FortSprite;
        }

        [Serializable]
        private class SpriteByStates
        {
            public FortState State;
            public Sprite FortSprite;
        }
    }
}
