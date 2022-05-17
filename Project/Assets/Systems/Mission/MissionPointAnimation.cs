using UnityEngine;

public class MissionPointAnimation : MonoBehaviour
{
    public const float RotationTime = 120f;
    private Vector3 _positionRef;

    private void Start()
    {
        _positionRef = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.up * Mathf.PingPong(Time.time, 1) + _positionRef;
        transform.Rotate(Vector3.up * (RotationTime * Time.deltaTime));
    }
}
