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
        //if (this.gameObject.name == "Vehicle-v4")
        //{
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        this.gameObject.transform.position = pos.position;
        //        this.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        //        this.gameObject.GetComponent<Rigidbody>().Sleep();
        //    }
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        this.gameObject.transform.position = pos.position;
        //        this.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        //        this.gameObject.GetComponent<Rigidbody>().Sleep();
        //    }
        //}
    }
}
