using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torsiones : MonoBehaviour
{
    [SerializeField]
    private float force;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float maxAngularVel;
    private Rigidbody rb;
    private bool grounded;

	// Start is called before the first frame update
	void Start()
    {
       grounded = true;
       rb = GetComponent<Rigidbody>();
       rb.maxAngularVelocity = maxAngularVel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(Vector3.right * force * Input.GetAxis("Horizontal"), ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" && (int)rb.velocity.magnitude == 0)
        {
            grounded = true;
        }
    }
}
