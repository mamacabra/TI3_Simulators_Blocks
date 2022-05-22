using UnityEngine;

public class MissionCompleted : MonoBehaviour
{
    public void OnClickCloseCompletedModal()
    {
        Destroy(gameObject);
    }
}
