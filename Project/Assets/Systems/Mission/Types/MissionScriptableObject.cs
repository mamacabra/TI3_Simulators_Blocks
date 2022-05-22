using UnityEngine;

public abstract class MissionScriptableObject : ScriptableObject
{
    [Header("Mission")] public new string name;

    public string description;

    public abstract void Init();
    public abstract void Completed();
}
