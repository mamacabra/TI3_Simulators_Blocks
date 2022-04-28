using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EixoRoda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        this.gameObject.transform.eulerAngles += new Vector3(0, horizontal * 2, 0);
        // this.gameObject.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, (),this.transform.eulerAngles.z);
        //this.gameObject.transform.Rotate(this.transform.rotation.x, horizontal * 30, this.transform.rotation.z, Space.World);
    }
}
