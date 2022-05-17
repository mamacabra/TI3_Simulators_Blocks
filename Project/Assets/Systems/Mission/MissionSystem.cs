using UnityEngine;
using UnityEngine.UI;

public class MissionSystem : MonoBehaviour
{
    public static MissionSystem Instance;
    public GameObject missionPanel;
    public Text missionList;
    private bool _display;
    private IMission[] _missions = new IMission[3];

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

    public void AddMission(IMission mission)
    {
        _missions[0] = mission;
        UpdateMissionList();

        mission.Init();
    }

    private void UpdateMissionList()
    {
        if (missionList != null)
        {
            IMission mission;
            missionList.text = "";

            for (int i = 0; i < _missions.Length; i++)
            {
                mission = _missions[0];
                missionList.text += mission.Name + "\n";
                missionList.text += mission.Description + "\n";
                missionList.text += "\n";
            }
        }
    }
}
