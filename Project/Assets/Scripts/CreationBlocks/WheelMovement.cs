using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    private WheelCollider wheelCollider;
    public Transform model;
    public float torque = 1000.0f;
    public float steerAngle = 35.0f;
    public float brakeTorque = 2000.0f;
    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        wheelCollider.motorTorque = v * torque;
        float h = Input.GetAxis("Horizontal");
        wheelCollider.steerAngle = h * steerAngle;
        

        if (Input.GetKey(KeyCode.Space))
        {
            wheelCollider.brakeTorque = brakeTorque;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            wheelCollider.brakeTorque = 0;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            wheelCollider.brakeTorque = brakeTorque;
        }
        else
        {
            wheelCollider.brakeTorque = 0;
        }
    }
    void LateUpdate()
    {
        Vector3 pos;
        Quaternion rot;

        // NOTE: Atualiza posição e rotação do modelo das rodas
        wheelCollider.GetWorldPose(out pos, out rot);
        model.rotation = rot;
        model.position = pos;
    }
}
