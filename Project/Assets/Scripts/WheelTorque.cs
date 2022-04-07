using UnityEngine;

public class WheelTorque : MonoBehaviour
{
    public WheelCollider wheel;
    public Transform model;
    public float torque = 1000f;
    public float brake = 4000f;

    private void Update()
    {
        var torqueForce = Input.GetAxis("Vertical") * torque;
        var brakeForce = Input.GetKey(KeyCode.Space) ? brake : 0;

        wheel.motorTorque = torqueForce;
        wheel.brakeTorque = brakeForce;
    }

    void LateUpdate()
    {
        Vector3 pos;
        Quaternion rot;

        // NOTE: Atualiza posição e rotação do modelo das rodas
        wheel.GetWorldPose(out pos, out rot);
        model.rotation = rot;
    }
}
