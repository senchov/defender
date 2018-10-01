using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class ArcherAtackView : MonoBehaviour, IAtackable
    {
        public event Action<string> OnAtack;

        public void Atack()
        {
           
        }     
    }
}
