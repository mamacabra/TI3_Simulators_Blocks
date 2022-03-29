using UnityEngine;

public class Articulation : MonoBehaviour
{
    public WheelCollider wheel;
    public float angle = 30;

    private void Update()
    {
        float a = Input.GetAxis("Horizontal");
        float steerAngle = Mathf.Lerp(wheel.steerAngle, a * angle, Time.deltaTime * 4);
        wheel.steerAngle = steerAngle;
    }
}
