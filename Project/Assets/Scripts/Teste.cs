using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    Rigidbody rb;
    public WheelCollider w;
    public float force;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = w.transform.forward;
        Debug.DrawRay(transform.position, dir * 3);
        var torqueForce = Input.GetAxis("Vertical");
        rb.AddForce(dir * force * torqueForce);
    }
}
