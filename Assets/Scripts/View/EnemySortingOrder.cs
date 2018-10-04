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
        [SerializeField] private int StartSortingOrder = 1;

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
            Debug.Log(DownPosY.ToString() + " " + GetMainCamera.ScreenToWorldPoint(new Vector2(0, 0)).ToString());
        }

        private void EnemyCreated(GameObject obj)
        {
            Enemies.Add(new Enemy(obj.transform, FortPosX, DownPosY));
            SetSortingOrder();
        }

        [ContextMenu("Set")]
        public void SetSortingOrder()
        {
            Enemies.Sort();

            int sortingOrder = StartSortingOrder;
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].SetSortingOrder(sortingOrder ++);
            }
        }

        private class Enemy : IComparable<Enemy>
        {
            private SpriteRenderer Sprite;
            public Transform EnemyTransform;
            private float FortPosX;
            private float DownPosY;

            public Enemy(Transform enemy, float fortPosX, float downPosY)
            {
                EnemyTransform = enemy;
                Sprite = enemy.GetComponent<SpriteRenderer>();
                FortPosX = fortPosX;
                DownPosY = downPosY;
            }

            public void SetSortingOrder(int order)
            {
                Sprite.sortingOrder = order;
            }

            public int CompareTo(Enemy other)
            {
                Debug.Log(this.EnemyTransform.name + other.EnemyTransform.name);
                float thisDistance = GetHeuristicDistance(this.EnemyTransform.position);
                float otherDistance = GetHeuristicDistance(other.EnemyTransform.position);

                Debug.Log(thisDistance + " " + otherDistance);

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
