using System;
using UnityEngine;

public class MissionPoint : MonoBehaviour
{
    public string missionName;
    private bool _isActived;

    private void OnTriggerEnter(Collider other)
    {
        if (_isActived == false)
        {
            Accept();
        }
    }

    private void Accept()
    {
        Type missionClass = Type.GetType(missionName);
        if (missionClass != null)
        {
            _isActived = true;
            IMission mission = (IMission) Activator.CreateInstance(missionClass);
            MissionSystem.Instance.AddMission(mission);
        }
    }
}
