using System;
using Assets.Scripts.Models;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    [CreateAssetMenu(fileName = "FortDamageController", menuName = "ScriptableObject/Battle/FortDamageController")]
    partial class FortDamageController : ScriptableObject
    {
        [Validate(typeof(IDamageProvider))] [SerializeField] private ScriptableObject DamageProviderModel;
        [Validate(typeof(IFortStatebleItem))] [SerializeField] private ScriptableObject Fort;

        private IFortStateReceiver FortStateReceiver;

        //call from main init unity event
        public void Init()
        {
            StatebleItemGetter.OnFortStateChanges += OnFortStateChanges;
        }

        private void OnFortStateChanges(FortState state)
        {
            FortStateReceiver.SetFortState(state);
        }

        public void InitFortStateReceiver(IFortStateReceiver stateReceiver)
        {
            FortStateReceiver = stateReceiver;
        }

        public void SubscribeToAtack(IAtackable atackable)
        {
            atackable.OnAtack += OnAtack;
        }

        private void OnAtack(string id)
        {
            int damage = DamageProviderGetter.GetDamage(id);
            DamagebleGetter.SetDamage(damage);
        }
    }
}
