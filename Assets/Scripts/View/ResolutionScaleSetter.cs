using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.View
{
    class ResolutionScaleSetter : MonoBehaviour
    {
        [SerializeField] private Transform Target;
        [SerializeField] private Vector2 EtalonResolution;
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

        private void Scale()
        {
            float width = Mathf.Clamp(GetMainCamera.pixelWidth / EtalonResolution.x, 1, 3);
            float height = Mathf.Clamp(GetMainCamera.pixelHeight / EtalonResolution.y, 1, 3);

            Target.localScale = new Vector3(width, height, Target.localScale.z);
        }

        private void Update()
        {
            Scale();
        }

    }
}
