using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.View
{
    class EnemySortingOrder : MonoBehaviour
    {
        [SerializeField] private Transform Fort;
        [Validate(typeof(ISpawnNotifier))] [SerializeField] private UnityEngine.Object SpawnNotifier;
        [SerializeField] private float StartZ = -0.1f;
        [SerializeField] private float StepZ = -0.1f;

        private List<Enemy> Enemies;
        private float FortPosX;
        private float DownPosY;

        private Camera MainCamera;
        private Camera GetMainCamera
        {
            get
            {
                if (MainCamera == null)
                    MainCamera = Camera.main;
                return MainCamera;
            }
        }

        private void Awake()
        {
            Enemies = new List<Enemy>();
            (SpawnNotifier as ISpawnNotifier).SpawnNotify += EnemyCreated;
            FortPosX = Fort.position.x;
            DownPosY = GetMainCamera.ScreenToWorldPoint(new Vector2(0, 0)).y;         
        }

        public void Update()
        {
            SetSortingOrder();
        }

        public void ReInit()
        {
            Enemies = new List<Enemy>();
        }

        private void EnemyCreated(GameObject obj)
        {
            Enemies.Add(new Enemy(obj.transform, FortPosX, DownPosY));
        }

        public void EnemyDestroyed(GameObject obj)
        {
            foreach (Enemy item in Enemies)
            {
                if (item.EnemyTransform == obj.transform)
                    Enemies.Remove(item);
            }
        }

        [ContextMenu("Set")]
        public void SetSortingOrder()
        {
            Enemies.Sort();

            float sortingOrder = StartZ;
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].EnemyTransform == null)
                {
                    Enemies.RemoveAt(i);
                    continue;
                }

                Enemies[i].SetSortingOrder(sortingOrder);
                sortingOrder += StepZ;
            }
        }

        private class Enemy : IComparable<Enemy>
        {           
            public Transform EnemyTransform;
            private float FortPosX;
            private float DownPosY;

            public Enemy(Transform enemy, float fortPosX, float downPosY)
            {
                EnemyTransform = enemy;              
                FortPosX = fortPosX;
                DownPosY = downPosY;
            }

            public void SetSortingOrder(float order)
            {
                Vector3 enemyPos = EnemyTransform.position;
                EnemyTransform.position = new Vector3(enemyPos.x, enemyPos.y, order);
            }

            public int CompareTo(Enemy other)
            {       
                float thisDistance = GetHeuristicDistance(this.EnemyTransform.position);
                float otherDistance = GetHeuristicDistance(other.EnemyTransform.position);              

                if (thisDistance < otherDistance)
                    return 1;

                if (thisDistance > otherDistance)
                    return -1;
                else
                    return 0;
            }

            private float GetHeuristicDistance(Vector3 enemyPos)
            {
                float distanceToFort = FortPosX - enemyPos.x;
                float distanceToDownScreen = enemyPos.y - DownPosY;
                return distanceToFort + distanceToDownScreen;
            }
        }
    }
}
