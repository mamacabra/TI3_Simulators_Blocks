using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "Missions/Delivery", order = 1)]
public class MissionTypeDelivery : MissionScriptableObject
{
    [Header("Delivery")] [Min(1)] public int minToComplete = 1;

    public GameObject target;
    public Vector3[] targetsPositions;

    [Header("Completed")] public GameObject completedCanvas;

    private int _targetFound;

    private void OnEnable()
    {
        _targetFound = 0;
    }

    public override void Init()
    {
        if (target)
        {
            foreach (var position in targetsPositions)
            {
                DeliveryTarget targetObject =
                    Instantiate(target, position, Quaternion.identity).GetComponent<DeliveryTarget>();
                targetObject.mission = this;
            }
        }
    }

    public override void Completed()
    {
        if (completedCanvas)
        {
            Instantiate(completedCanvas);
        }
    }

    public void TargetFound()
    {
        _targetFound += 1;

        if (_targetFound >= minToComplete)
        {
            Completed();
        }
    }
}
