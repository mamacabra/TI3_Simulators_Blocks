using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleV1Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.gameObject.transform.position = new Vector3(0,4,0);
            this.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
            this.gameObject.GetComponent<Rigidbody>().Sleep();
        }
    }
}
