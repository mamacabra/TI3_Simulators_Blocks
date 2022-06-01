using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigureJoint : MonoBehaviour
{
    // public GameObject txt;
    public bool canDestroy = false;
    public float rayDistance = 0.15f;
    public List<int> nonCollidingDirs;
    Rigidbody rb;
    private readonly RaycastHit[] _hit = new RaycastHit[6];
    private readonly Vector3[] _directions = {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right,
        Vector3.up,
        Vector3.down
    };

    GameObject main;
    // Start is called before the first frame update


    private void Awake() {
        
        rb = this.gameObject.GetComponent<Rigidbody>();
        // txt = GameObject.Find("Textinho");
        main = GameObject.Find("BloquinhoMain");

    }
    void Start()
    {
        // rb.useGravity = false;
        // rb.constraints = RigidbodyConstraints.FreezeAll;
        // Invoke("Configure", 1.5f);
        // Configure();
        TestDirections();
    }
    void Configure()
    {
        if (this.gameObject == main)
        {
            for (int i = 0; i < _directions.Length; i++)
            {
                bool colliding = Physics.Raycast(transform.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);

                if (!(colliding && _hit[i].collider.gameObject.tag == "BlockBuild"))
                {
                    nonCollidingDirs.Add(i);
                }
            }
        }
        else
        {
            this.gameObject.AddComponent<FixedJoint>().connectedBody = main.gameObject.GetComponent<Rigidbody>();
            for (int i = 0; i < _directions.Length; i++)
            {
                bool colliding = Physics.Raycast(transform.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);

                if (colliding && _hit[i].collider.gameObject.tag == "BlockBuild")
                {
                    FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                    Rigidbody nearblockRB = _hit[i].collider.gameObject.GetComponent<Rigidbody>();
                    joint.connectedBody = nearblockRB;
                    joint.enablePreprocessing = false;
                }
                else
                {
                    nonCollidingDirs.Add(i);
                }
            }
        }
        // rb.useGravity = true;
        // rb.constraints = RigidbodyConstraints.None;


    }

    // Update is called once per frame
    void Update()
    {
        // TestDirections();
        TestDraw();
        canDestroy = EditMode.editMode.canDestroy;
        // if (Input.GetKeyDown(KeyCode.J))
        // {
        //     Configure();
        // }
        // if (EditMode.editMode.isEdit)
        // {
        //     this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        //     this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        //     this.gameObject.GetComponent<Rigidbody>().Sleep();
        //     this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        // }
        // else
        // {
        //     this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        //     this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //     this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        // }
    }

    public void TestDirections()
    {
        // nonCollidingDirs.Clear();
        for (int i = 0; i < _directions.Length; i++)
        {
            bool colliding = Physics.Raycast(transform.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);

            if (!(colliding && _hit[i].collider.gameObject.tag == "BlockBuild"))
            {
                print(name + " - " + "Direção: " + i + ";");
                if (!nonCollidingDirs.Contains(i))
                {
                    nonCollidingDirs.Add(i);
                }
            }
        }
    }
    void TestDraw()
    {
        for (int i = 0; i < _directions.Length; i++)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance))
            {
                if (_hit[i].collider.gameObject.tag == "BlockBuild")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(_directions[i]) * _hit[i].distance, Color.blue);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(_directions[i]) * rayDistance, Color.white);
            }
        }
    }
    // private void OnMouseDown()
    // {
        // string str = "usando gravidade?: " + rb.useGravity + "\n";
        // str += "Constraints: " + rb.constraints + "\n";
        // txt.GetComponent<Text>().text = str;
        // FixedJoint[] fixeds = GetComponents<FixedJoint>();
        // string str = "";
        // foreach (var item in fixeds)
        // {
        //     str += " " + item.connectedBody.name + " - ";
        // }
        // str += "Catapinbas";
        // txt.GetComponent<Text>().text = str;
        // print(gameObject.name);
        // if (canDestroy && transform.tag != "BlockMain")
        // {
            // GameObject[] gObj = GameObject.FindGameObjectsWithTag("BlockBuild");
            // foreach (GameObject go in gObj)
            // {
            //     // try
            //     // {
            //     go.GetComponent<ConfigureJoint>().TestDirections();
            //     // }
            //     // catch (System.Exception ex)
            //     // {
            //     //     Debug.Log("deu ruim: " + ex.Message); // TODO
            //     // }
            // }
    //         Destroy(this.gameObject);
    //     }
    // }
}
