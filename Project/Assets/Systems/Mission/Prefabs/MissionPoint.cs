using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class MissionPoint : MonoBehaviour
{
    public MissionScriptableObject mission;
    private bool _isActived;

    private void Start()
    {
        SphereCollider collider = gameObject.GetComponent<SphereCollider>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActived == false)
        {
            _isActived = true;
            ShowModal();
        }
    }

    private void ShowModal()
    {
        Accept();
    }

    private void Accept()
    {
        if (mission)
        {
            Destroy(gameObject);
            mission.Init();
        }
    }
}
