using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(fileName = "SpawnPointsModel", menuName = "ScriptableObject/Spawn/SpawnPointsModel")]
    class SpawnPointsModel : ScriptableObject, ISpawnPointModel
    {
        [SerializeField] private float MinHeight = 0.05f;
        [SerializeField] private float MaxHeight = 0.4f;
        [SerializeField] private float Step = 0.05f;
        [SerializeField] private float HorizontalOffset = 20;

        private Camera MainCamera;
        List<Vector3> SpawnPoints;

        private Camera GetMainCamera
        {
            get
            {
                if (MainCamera == null)
                    MainCamera = Camera.main;
                return MainCamera;
            }
        }

        public Vector3 GetSpawnPoint()
        {
            FillSpawnPoints();

            int pointIndex = Random.Range(0, SpawnPoints.Count);
            return SpawnPoints[pointIndex];
        }

        private void FillSpawnPoints()
        {
            if (SpawnPoints == null)
            {
                Vector3 leftDownCorner = GetMainCamera.ScreenToWorldPoint(new Vector2(0, 0));
                Vector3 leftUpCorner = GetMainCamera.ScreenToWorldPoint(new Vector2(0, GetMainCamera.pixelHeight));
                float currentHeight = MinHeight;
                float heightDiff = leftUpCorner.y - leftDownCorner.y;
                int pointCount = (int)((MaxHeight - MinHeight) / Step);
                for (int i = 0; i < pointCount; i++)
                {
                    float xPos = leftDownCorner.x - HorizontalOffset;
                    float yPos = leftDownCorner.y + heightDiff * currentHeight;
                    Vector3 spawnPoint = new Vector3(xPos, yPos, 0);
                    currentHeight += Step;
                    SpawnPoints.Add(spawnPoint);
                }
            }
        }

    }
}
