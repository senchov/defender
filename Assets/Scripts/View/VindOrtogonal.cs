using UnityEngine;

namespace Assets.Scripts.View
{
    class VindOrtogonal : MonoBehaviour
    {
        [SerializeField] private Transform Start;
        [SerializeField] private Transform End;
        [SerializeField] private Transform Mid;

        [ContextMenu ("Find")]
        public void Find()
        {
            Vector2 dir = End.transform.position - Start.transform.position;
            dir *= 0.5f;
            dir = Quaternion.Euler(0,0,-45.0f) * dir;
            Vector3 findPos = new Vector3(dir.x, dir.y,0) + Start.transform.position;
            Mid.transform.position = findPos;
        }
    }
}
