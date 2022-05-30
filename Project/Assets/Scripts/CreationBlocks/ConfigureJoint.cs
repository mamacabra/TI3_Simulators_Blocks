using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureJoint : MonoBehaviour
{
    public bool canDestroy = false;
    public float rayDistance = 0.15f;
    public List<int> nonCollidingDirs;
    private readonly RaycastHit[] _hit = new RaycastHit[6];
    private readonly Vector3[] _directions = {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right,
        Vector3.up,
        Vector3.down
    };
    // Start is called before the first frame update
    
    void Start()
    {
        
        if (transform.tag == "BlockMain")
        {
            for (int i = 0; i < _directions.Length; i++)
            {
                bool colliding = Physics.Raycast(transform.position, _directions[i], out _hit[i], rayDistance);

                if (!(colliding && _hit[i].collider.gameObject.tag == "BlockBuild"))
                {
                    nonCollidingDirs.Add(i);
                }
            }
        }
        else
        {
            this.gameObject.GetComponent<FixedJoint>().connectedBody = GameObject.Find("BloquinhoMain").gameObject.GetComponent<Rigidbody>();
            for (int i = 0; i < _directions.Length; i++)
            {
                bool colliding = Physics.Raycast(transform.position, _directions[i], out _hit[i], rayDistance);

                if (colliding && _hit[i].collider.gameObject.tag == "BlockBuild")
                {
                    FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                    Rigidbody nearblockRB = _hit[i].collider.gameObject.GetComponent<Rigidbody>();
                    joint.connectedBody = nearblockRB;
                    // joint.enablePreprocessing = false;
                }
                else
                {
                    nonCollidingDirs.Add(i);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TestDirections();
        TestDraw();
        canDestroy = EditMode.editMode.canDestroy;
        if (EditMode.editMode.isEdit)
        {
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void TestDirections()
    {
        for (int i = 0; i < _directions.Length; i++)
        {
            bool colliding = Physics.Raycast(transform.position, _directions[i], out _hit[i], rayDistance);

            if (!(colliding && _hit[i].collider.gameObject.tag == "BlockBuild"))
            {
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
            if (Physics.Raycast(transform.position, _directions[i], out _hit[i], rayDistance))
            {
                if (_hit[i].collider.gameObject.tag == "BlockBuild")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(_directions[i]) * _hit[i].distance, Color.blue);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, _directions[i] * rayDistance, Color.white);
            }
        }
    }
    private void OnMouseDown()
    {
        if (canDestroy && transform.tag != "BlockMain")
        {
            Destroy(this.gameObject);
        }
    }
}
