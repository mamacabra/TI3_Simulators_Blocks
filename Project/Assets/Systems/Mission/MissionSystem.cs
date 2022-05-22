using UnityEngine;
using UnityEngine.UI;

public class MissionSystem : MonoBehaviour
{
    public static MissionSystem Instance;
    public GameObject missionPanel;
    public Text missionList;
    private bool _display;
    private MissionScriptableObject[] _missions = new MissionScriptableObject[3];

    private void Start()
    {
        missionPanel.SetActive(_display);

        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _display = !_display;
            missionPanel.SetActive(_display);
        }
    }

    public void AddMission(MissionScriptableObject mission)
    {
        _missions[0] = mission;
        UpdateMissionList();

        mission.Init();
    }

    private void UpdateMissionList()
    {
        if (missionList != null)
        {
            MissionScriptableObject mission;
            missionList.text = "";

            for (int i = 0; i < _missions.Length; i++)
            {
                mission = _missions[0];
                missionList.text += mission.name + "\n";
                missionList.text += mission.description + "\n";
                missionList.text += "\n";
            }
        }
    }
}
