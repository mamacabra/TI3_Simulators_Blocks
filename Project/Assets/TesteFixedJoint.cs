using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteFixedJoint : MonoBehaviour
{
    private GameObject main;
    private GameObject txt;
    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("Cubinho");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            FixedJoint joint = this.gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = main.gameObject.GetComponent<Rigidbody>();
            txt.GetComponent<Text>().text = joint.connectedBody.name;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            main.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            main.transform.position += new Vector3(0, 2, 0);
        }
    }
}
