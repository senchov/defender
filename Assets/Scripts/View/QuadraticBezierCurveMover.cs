using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuadraticBezierCurveMover : MonoBehaviour
{
    [SerializeField] private Transform MoveObject;

    [SerializeField] private float FlyTime;
    [SerializeField] [Range(0, 1)] private float Distance;
    [SerializeField] private MovePoints Points;

    [SerializeField] public UnityEvent OnMoveStart;
    [SerializeField] public UnityEvent OnMoveComplete;
    [SerializeField] private bool IsShoot = false;

    public float FutureOffset = 0.1f;
    float MaxDistance = 0.99f;

    private void Update()
    {
        if (!IsShoot)
            return;

        MoveObject.transform.localPosition = GetCurvePoint(Mathf.Clamp(Distance, 0, MaxDistance), Points.Start.localPosition,
            Points.Controll.localPosition, Points.End.localPosition);

        RotateTarget(Distance);
    }

    public float SetDistance
    {
        set { Distance = value; }
    }

    [ContextMenu("Move")]
    public void Move()
    {
        Move(FlyTime, Points.Start.localPosition, Points.Controll.localPosition, Points.End.localPosition);
    }

    public void Move(float time, Vector3 start, Vector3 controll, Vector3 end)
    {
        StartCoroutine(MoveTarget(time, start, controll, end));
    }

    private IEnumerator MoveTarget(float time, Vector3 start, Vector3 controll, Vector3 end)
    {
        if (time == 0)
            yield break;

        OnMoveStart.Invoke();
        float moveTime = 0;
        while (moveTime < time)
        {
            float distance = moveTime / time;
            moveTime += Time.deltaTime;

            MoveObject.transform.localPosition = GetCurvePoint(Mathf.Clamp(Distance, 0, MaxDistance), start,
                controll, end);
            RotateTarget(distance);

            yield return null;
        }
        OnMoveComplete.Invoke();
    }

    private void RotateTarget(float distance)
    {
        Vector3 futurePos = GetCurvePoint(distance + FutureOffset, Points.Start.localPosition,
        Points.Controll.localPosition, Points.End.localPosition);

        Vector2 futureVector = futurePos - MoveObject.transform.localPosition;
        float angle = Vector2.Angle(new Vector2(-1, 0), futureVector);

        MoveObject.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    private Vector3 GetCurvePoint(float t, Vector3 start, Vector3 controll, Vector3 target)
    {
        t = Mathf.Clamp(t, 0, 1);
        Vector3 curvePoint = Vector3.zero;
        curvePoint.x = (1 - t) * (1 - t) * start.x + 2 * (1 - t) * t * controll.x + t * t * target.x;
        curvePoint.y = (1 - t) * (1 - t) * start.y + 2 * (1 - t) * t * controll.y + t * t * target.y;
        curvePoint.z = Mathf.Lerp(start.z, target.z, t);
        return curvePoint;
    }

    [System.Serializable]
    private class MovePoints
    {
        public Transform Start;
        public Transform Controll;
        public Transform End;
    }
}