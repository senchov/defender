using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.View
{
    class CameraAnchor : MonoBehaviour
    {
        [SerializeField] private Transform Target;
        [SerializeField] private ScreenPoint Point;

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

        private Dictionary<ScreenPoint, Func<Vector3>> VectorByScreenPoint;

        private void Start()
        {
            VectorByScreenPoint = new Dictionary<ScreenPoint, Func<Vector3>>();

            VectorByScreenPoint.Add(ScreenPoint.LeftDown,GetLeftDownCorner);
            VectorByScreenPoint.Add(ScreenPoint.LeftMiddle, GetLeftMiddlePoint);
            VectorByScreenPoint.Add(ScreenPoint.LeftUp, GetLeftUpCorner);
            VectorByScreenPoint.Add(ScreenPoint.MiddleUp, GetMiddleUpPoint);
            VectorByScreenPoint.Add(ScreenPoint.Center, GetCenterPoint);
            VectorByScreenPoint.Add(ScreenPoint.MiddleDown, GetMiddleDownPoint);
            VectorByScreenPoint.Add(ScreenPoint.RightDown, GetRightDownPoint);
            VectorByScreenPoint.Add(ScreenPoint.RightMiddle, GetRightMiddlePoint);
            VectorByScreenPoint.Add(ScreenPoint.RightUp, GetRightUpCorner);
        }

        public void Update()
        {
            SetPosition();
        }
      
        public void SetPosition()
        {
            Vector3 pos = VectorByScreenPoint[Point] ();
            pos.z = Target.position.z;
            Target.position = pos;
        }

        private Vector3 GetLeftDownCorner()
        {
            return GetMainCamera.ScreenToWorldPoint(new Vector2(0, 0));
        }

        private Vector3 GetLeftMiddlePoint()
        {
            float width = 0;
            float height = GetMainCamera.pixelHeight / 2;
            return GetMainCamera.ScreenToWorldPoint(new Vector2(width, height));
        }

        private Vector3 GetLeftUpCorner()
        {
            float width = 0;
            float height = GetMainCamera.pixelHeight;
            return GetMainCamera.ScreenToWorldPoint(new Vector2(width, height));
        }

        private Vector3 GetMiddleDownPoint()
        {
            float width = GetMainCamera.pixelWidth / 2;
            float height = 0;
            return GetMainCamera.ScreenToWorldPoint(new Vector2(width, height));
        }

        private Vector3 GetCenterPoint()
        {
            float width = GetMainCamera.pixelWidth / 2;
            float height = GetMainCamera.pixelHeight / 2;
            return GetMainCamera.ScreenToWorldPoint(new Vector2(width, height));
        }

        private Vector3 GetMiddleUpPoint()
        {
            float width = GetMainCamera.pixelWidth / 2;
            float height = GetMainCamera.pixelHeight;
            return GetMainCamera.ScreenToWorldPoint(new Vector2(width, height));
        }

        private Vector3 GetRightDownPoint()
        {
            float width = GetMainCamera.pixelWidth;
            float height = 0;
            return GetMainCamera.ScreenToWorldPoint(new Vector2(width, height));
        }

        private Vector3 GetRightMiddlePoint()
        {
            float width = GetMainCamera.pixelWidth;
            float height = GetMainCamera.pixelHeight / 2;
            return GetMainCamera.ScreenToWorldPoint(new Vector2(width, height));
        }

        private Vector3 GetRightUpCorner()
        {
            float width = GetMainCamera.pixelWidth;
            float height = GetMainCamera.pixelHeight;
            return GetMainCamera.ScreenToWorldPoint(new Vector2(width, height));
        }

        [Serializable]
        private enum ScreenPoint
        {
            LeftDown,
            LeftMiddle,
            LeftUp,
            MiddleDown,
            Center,
            MiddleUp,
            RightDown,
            RightMiddle,
            RightUp
        }
    }
}
