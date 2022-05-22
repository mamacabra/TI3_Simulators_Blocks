using UnityEngine;

public class DeliveryTarget : MonoBehaviour
{
    public MissionTypeDelivery mission;
    private bool _found;

    private void OnTriggerEnter(Collider other)
    {
        if (mission && _found == false)
        {
            _found = true;
            mission.TargetFound();
            Destroy(gameObject);
        }
    }
}
