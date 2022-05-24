using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    float rayDistance = 0.15f;
    public GameObject previewBloc;
    public GameObject bloc;
    public bool isColliding = false;
    public float distanceOffset = 1.5f;
    public float offset = 0.05f;
    public Vector3 hitPoint;
    private readonly RaycastHit[] _hit = new RaycastHit[6];
    private readonly Vector3[] _directions = {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right,
        Vector3.up,
        Vector3.down
    };

    private void Update()
    {
        if (EditMode.editMode.canCreate)
        {
            DefinePosition();
            TestDraw();
            (GameObject obj, int dir) = IndentifyIntersectBloc();
            // print(dir);
            SetPosition(obj, dir);
            if (isColliding)
            {
                GenerateBloc(obj, dir);
            }
        }
        else
        {
            this.gameObject.transform.position = new Vector3(1000,1000,1000);
            previewBloc.transform.position = new Vector3(1000, 1000, 1000);
        }
    }
    private void GenerateBloc(GameObject obj, int dir)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var myBlock = Instantiate(bloc, previewBloc.transform.position, Quaternion.identity);
            myBlock.transform.parent = GameObject.Find("Vehicle-v4").transform;
            obj.GetComponent<ConfigureJoint>().nonCollidingDirs.Remove(dir);
        }
    }

    public void SetPosition(GameObject obj, int direction)
    {
        if (obj != null)
        {
            if (obj.GetComponent<ConfigureJoint>().nonCollidingDirs.Contains(direction))
            {
                Vector3 objPos = obj.transform.position;
                switch (direction)
                {
                    case 0://forward
                        objPos.z += distanceOffset;
                        previewBloc.transform.position = objPos;
                        // GenerateBloc();
                        break;
                    case 1://back
                        objPos.z += -distanceOffset;
                        previewBloc.transform.position = objPos;
                        // GenerateBloc();
                        break;
                    case 2://left
                        objPos.x += -distanceOffset;
                        previewBloc.transform.position = objPos;
                        // GenerateBloc();
                        break;
                    case 3://right
                        objPos.x += distanceOffset;
                        previewBloc.transform.position = objPos;
                        // GenerateBloc();
                        break;
                    case 4://up
                        objPos.y += distanceOffset;
                        previewBloc.transform.position = objPos;
                        // GenerateBloc();
                        break;
                    case 5://down
                        objPos.y += -distanceOffset;
                        previewBloc.transform.position = objPos;
                        // GenerateBloc();
                        break;
                    default:
                        break;
                }
                isColliding = true;
            }
            // foreach (int dir in obj.GetComponent<ConfigureJoint>().nonCollidingDirs)
            // {
            //     if (dir == direction)
            //     {
            //         Vector3 objPos = obj.transform.position;
            //         switch (dir)
            //         {
            //             case 0://forward
            //                 objPos.z += distanceOffset;
            //                 previewBloc.transform.position = objPos;
            //                 obj.GetComponent<ConfigureJoint>().nonCollidingDirs.Remove(dir);
            //                 // GenerateBloc();
            //                 break;
            //             case 1://back
            //                 objPos.z += -distanceOffset;
            //                 previewBloc.transform.position = objPos;
            //                 obj.GetComponent<ConfigureJoint>().nonCollidingDirs.Remove(dir);
            //                 // GenerateBloc();
            //                 break;
            //             case 2://left
            //                 objPos.x += -distanceOffset;
            //                 previewBloc.transform.position = objPos;
            //                 obj.GetComponent<ConfigureJoint>().nonCollidingDirs.Remove(dir);
            //                 // GenerateBloc();
            //                 break;
            //             case 3://right
            //                 objPos.x += distanceOffset;
            //                 previewBloc.transform.position = objPos;
            //                 obj.GetComponent<ConfigureJoint>().nonCollidingDirs.Remove(dir);
            //                 // GenerateBloc();
            //                 break;
            //             case 4://up
            //                 objPos.y += distanceOffset;
            //                 previewBloc.transform.position = objPos;
            //                 obj.GetComponent<ConfigureJoint>().nonCollidingDirs.Remove(dir);
            //                 // GenerateBloc();
            //                 break;
            //             case 5://down
            //                 objPos.y += -distanceOffset;
            //                 previewBloc.transform.position = objPos;
            //                 obj.GetComponent<ConfigureJoint>().nonCollidingDirs.Remove(dir);
            //                 // GenerateBloc();
            //                 break;
            //             default:
            //                 break;
            //         }
            //     }
            // }
            // isColliding = true;
        }
        else
        {
            isColliding = false;
            previewBloc.transform.position = new Vector3(1000, 1000, 1000);
        }
    }

    (GameObject, int direction) IndentifyIntersectBloc()
    {
        GameObject obj = null;
        int dir = -1;

        for (int i = 0; i < _directions.Length; i++)
        {
            // print("entrou1");
            if (Physics.Raycast(transform.position, _directions[i], out _hit[i], rayDistance))
            {
                // print("entrou2");
                if (_hit[i].collider.gameObject.layer == LayerMask.NameToLayer("Block"))
                {
                    // print("entrou3");
                    obj = _hit[i].collider.gameObject;
                    if (i % 2 == 0)
                    {
                        dir = i + 1;
                    }
                    else
                    {
                        dir = i - 1;
                    }

                    break;
                }
            }
        }
        return (obj, dir);
    }

    private void OnDrawGizmos()
    {
        Color nColor = Color.white;
        nColor.a = 0.3f;
        Gizmos.color = nColor;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
    void TestDraw()
    {
        for (int i = 0; i < _directions.Length; i++)
        {
            if (Physics.Raycast(transform.position, _directions[i], out _hit[i], rayDistance))
            {
                if (_hit[i].collider.gameObject.layer == LayerMask.NameToLayer("Block"))
                {
                    Debug.DrawRay(transform.position, _directions[i] * rayDistance, Color.red);
                    // print(_hit[i].normal);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, _directions[i] * rayDistance, Color.white);
            }
        }
    }
    void DefinePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 pos = hit.point;
            hitPoint = hit.point;

            if (hit.normal.x < 0)
            {
                pos.x -= offset;
            }
            else if (hit.normal.x > 0)
            {
                pos.x += offset;
            }
            if (hit.normal.y < 0)
            {
                pos.y -= offset;
            }
            else if (hit.normal.y > 0)
            {
                pos.y += offset;
            }
            if (hit.normal.z < 0)
            {
                pos.z -= offset;
            }
            else if (hit.normal.z > 0)
            {
                pos.z += offset;
            }

            this.gameObject.transform.position = pos;
        }
    }
}
