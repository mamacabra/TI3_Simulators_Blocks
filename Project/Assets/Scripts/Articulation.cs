using UnityEngine;

public class Articulation : MonoBehaviour
{
    public Transform model;
    public WheelCollider wheel;
    public float angle = 30;

    private void Update()
    {
        float a = Input.GetAxis("Horizontal");
        float steerAngle = Mathf.Lerp(wheel.steerAngle, a * angle, Time.deltaTime * 4);
        wheel.steerAngle = steerAngle;
    }

    void LateUpdate()
    {
        Vector3 pos;
        Quaternion rot;

        // NOTE: Atualiza posição e rotação do modelo das rodas
        wheel.GetWorldPose(out pos, out rot);
        //model.position = pos;
        model.rotation = rot;
    }
}
