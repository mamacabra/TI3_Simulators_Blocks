using UnityEngine;

public class WheelTorque : MonoBehaviour
{
    private WheelCollider _wheel;
    public float torque = 1000;
    public float brake = 3000;

    private void Start()
    {
        _wheel = GetComponent<WheelCollider>();
    }

    private void Update()
    {
        var torqueForce = Input.GetAxis("Vertical") * torque;
        var brakeForce = Input.GetKey(KeyCode.Space) ? brake : 0;

        _wheel.motorTorque = torqueForce;
        _wheel.brakeTorque = brakeForce;
    }
}
