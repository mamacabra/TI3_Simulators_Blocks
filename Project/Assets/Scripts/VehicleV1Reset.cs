using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleV1Reset : MonoBehaviour
{
    public Transform pos;
    public Transform pastPos;
    public Transform editPos;
    // Start is called before the first frame update
    void Start()
    {
        // this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        // this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    public void EditVehicle()
    {
        if (EditMode.editMode.isEdit)
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.gameObject.transform.SetPositionAndRotation(editPos.position, editPos.rotation);
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.transform.SetPositionAndRotation(pastPos.position, pastPos.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}