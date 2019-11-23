using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forces : MonoBehaviour
{
    [SerializeField]
    private float force;
    [SerializeField]
    private bool withMass;
    [SerializeField]
    private bool isContinuous;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(-transform.forward * force);
            rb.AddForce(Vector3.up * force);
        }*/

        if (Input.GetKey(KeyCode.W) && isContinuous)
        {
            if (withMass)
            {
                rb.AddForce(Vector3.up * force, ForceMode.Force);
            }
            else
            {
                rb.AddForce(Vector3.up * force, ForceMode.Acceleration);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !isContinuous)
        {
            if (withMass)
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(Vector3.up * force, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print(rb.velocity.magnitude + " UPS");
            //rb.velocity = new Vector3(0, 9.8f, 0);
            // rb.velocity = Vector3.up * force;
        }
    }
}
