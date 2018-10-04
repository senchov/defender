using System;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "FortHealthModel", menuName = "ScriptableObject/Battle/FortHealthModel")]
    class FortHealthModel : ScriptableObject, IDamageble, IFortStatebleItem
    {
        public int Health;
        public int StartHealth;
        [SerializeField] private StatesSettingItem[] SettingItems;
        

        public event Action<FortState> OnFortStateChanges;
        private FortState CurrentState = FortState.Powerfull;

        private void OnEnable()
        {
            Health = StartHealth;
        }

        public void SetDamage(int damage)
        {
            Health -= damage;

            for (int i = 0; i < SettingItems.Length; i++)
            {
                if (IsHealthInRange(i))
                {
                    FortState state = SettingItems[i].State;                
                    if (state != CurrentState)
                    {
                        CurrentState = state;
                        OnFortStateChangeHandler();
                    }
                }
            }
        }

        private void OnFortStateChangeHandler()
        {
            Debug.Log("FortHealthModel " + CurrentState);
            if (OnFortStateChanges != null)
                OnFortStateChanges(CurrentState);
        }

        private bool IsHealthInRange(int i)
        {            
            return SettingItems[i].MinHealth < Health && Health <= SettingItems[i].MaxHealth;
        }

        [Serializable]
        private class StatesSettingItem
        {
            public FortState State;
            public float MaxHealth;
            public float MinHealth;           
        }
    }

    public enum FortState
    {
        Powerfull,
        Sosopwerfull,
        AlmostDead,
        Dead
    }
}
