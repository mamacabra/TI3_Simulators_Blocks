using UnityEngine;

public class DeliveryTarget : MonoBehaviour
{
    public MissionTypeDelivery mission;

    private void OnTriggerEnter(Collider other)
    {
        if (mission)
        {
            mission.TargetFound();
            Destroy(gameObject);
        }
    }
}
