using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour
{
    private const float MassDefault = 1f;
    private const float RaycastDistance = 0.4f;

    private readonly RaycastHit[] _hit = new RaycastHit[6];
    private readonly Vector3[] _directions = {
        Vector3.forward,
        // Vector3.back,
        // Vector3.left,
        Vector3.right,
        Vector3.up,
        // Vector3.down
    };

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = MassDefault;

        for (int i = 0; i < _directions.Length; i++)
        {
            bool colliding = Physics.Raycast(transform.position, _directions[i], out _hit[i], RaycastDistance);

            if (colliding)
            {
                HingeJoint joint = gameObject.AddComponent<HingeJoint>();
                joint.connectedBody = _hit[i].rigidbody;

                joint.enableCollision = true;
                joint.massScale = 500f;
                joint.connectedMassScale = 5f;

                // joint.anchor = _directions[i] / 2;
                // joint.axis = _directions[i];

                joint.useLimits = true;
                joint.limits = new JointLimits
                {
                    contactDistance = 0f
                };
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < _directions.Length; i++)
        {
            if (_hit[i].rigidbody != null)
            {
                Debug.DrawRay(transform.position, _directions[i] * RaycastDistance, Color.yellow);
            }
            else
            {
                Debug.DrawRay(transform.position, _directions[i] * RaycastDistance, Color.gray);
            }
        }
    }
}
