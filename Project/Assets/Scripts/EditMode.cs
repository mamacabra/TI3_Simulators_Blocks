using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class EditMode : MonoBehaviour
{
    public static EditMode editMode;
    public CinemachineVirtualCamera cmCamera;
    public Text editBtText, sideBtText, topBtText;
    public GameObject panelButtons;
    public GameObject vehicle;
    private CinemachineTransposer cmTransposer;
    private Vector3 lastOffset = new Vector3(0, 4, -4);
    private bool side = false;
    private bool top = false;
    public bool isEdit = false;
    public int zoomValue = 4;
    public bool canDestroy = false;
    public bool canCreate = false;
    // public List<GameObject> blocs;
    public void EditCarClick()
    {
        if (!isEdit)
        {
            cmTransposer.m_XDamping = 0;
            cmTransposer.m_YDamping = 0;
            cmTransposer.m_ZDamping = 0;
            lastOffset = new Vector3(0, zoomValue, 0);
            cmTransposer.m_FollowOffset = lastOffset;
            editBtText.text = "Fechar\nEdição";
            panelButtons.SetActive(true);
            vehicle.GetComponent<VehicleV1Reset>().pastPos.SetPositionAndRotation(vehicle.transform.position, vehicle.transform.rotation);
            // vehicle.GetComponent<VehicleV1Reset>().EditVehicle();
        }
        else
        {
            cmTransposer.m_XDamping = 1;
            cmTransposer.m_YDamping = 1;
            cmTransposer.m_ZDamping = 1;
            lastOffset = new Vector3(0, 4, -4);
            cmTransposer.m_FollowOffset = lastOffset;
            editBtText.text = "Editar\nVeículo";
            canCreate = false;
            canDestroy = false;
            panelButtons.SetActive(false);
        }
        isEdit = !isEdit;
        vehicle.GetComponent<VehicleV1Reset>().EditVehicle();
    }
    public void HorizontalView()
    {
        if (side)
        {
            lastOffset = new Vector3(zoomValue, 0, 0);
            cmTransposer.m_FollowOffset = lastOffset;
            sideBtText.text = "ESQUERDA";
        }
        else
        {
            lastOffset = new Vector3(-zoomValue, 0, 0);
            cmTransposer.m_FollowOffset = lastOffset;
            sideBtText.text = "DIREITA";
        }
        side = !side;
    }
    public void VerticalView()
    {
        if (top)
        {
            lastOffset = new Vector3(0, zoomValue, 0);
            cmTransposer.m_FollowOffset = lastOffset;
            topBtText.text = "BAIXO";
        }
        else
        {
            lastOffset = new Vector3(0, -zoomValue, 0);
            cmTransposer.m_FollowOffset = lastOffset;
            topBtText.text = "CIMA";
        }
        top = !top;
    }
    public void ZoomPlusClick(int zoomQuantity)
    {
        // if (zoomValue  2)
        // {
        zoomValue += zoomQuantity;
        // }
        if (lastOffset.x > 0)
        {
            lastOffset = new Vector3(zoomValue, 0, 0);
        }
        else if (lastOffset.x < 0)
        {
            lastOffset = new Vector3(-zoomValue, 0, 0);
        }
        else if (lastOffset.y > 0)
        {
            lastOffset = new Vector3(0, zoomValue, 0);
        }
        else if (lastOffset.y < 0)
        {
            lastOffset = new Vector3(0, -zoomValue, 0);
        }
        cmTransposer.m_FollowOffset = lastOffset;
    }
    public void ZoomMinusClick(int zoomQuantity)
    {
        if (zoomValue > 2)
        {
            zoomValue -= zoomQuantity;
        }
        if (lastOffset.x > 0)
        {
            lastOffset = new Vector3(zoomValue, 0, 0);
        }
        else if (lastOffset.x < 0)
        {
            lastOffset = new Vector3(-zoomValue, 0, 0);
        }
        else if (lastOffset.y > 0)
        {
            lastOffset = new Vector3(0, zoomValue, 0);
        }
        else if (lastOffset.y < 0)
        {
            lastOffset = new Vector3(0, -zoomValue, 0);
        }
        cmTransposer.m_FollowOffset = lastOffset;
    }

    public void DestroyClick()
    {
        canCreate = false;
        canDestroy = !canDestroy;
    }
    public void CreateClick()
    {
        canDestroy = false;
        canCreate = !canCreate;
    }
    void Start()
    {
        cmTransposer = cmCamera.GetCinemachineComponent<CinemachineTransposer>();
        // GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("BlockBuild");
        // foreach (var item in gameObjects)
        // {
        //     blocs.Add(item);
        // }
    }
    private void Awake() {
        editMode = this;
    }
}
