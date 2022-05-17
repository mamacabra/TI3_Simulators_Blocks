using System;
using UnityEngine;

[Serializable]
public class MontainMission001 : IMission
{
    private const string MissionName = "Missão da Montanha 001";
    private const string MissionDescription = "Encontre os dois pontos de controle na montanha.";

    public string Name => MissionName;
    public string Description => MissionDescription;

    public void Init()
    {
        Debug.Log($"INIT MISSION:{MissionName}");
    }

    public void Complete()
    {
        Debug.Log($"COMPLETE MISSION:{MissionName}");
    }

    public void Fail()
    {
        Debug.Log($"FAIL MISSION:{MissionName}");
    }

    public void DrawInfos()
    {
        Debug.Log($"DRAW INFOS MISSION:{MissionName}");
    }
}
