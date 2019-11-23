using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoImpulsionInversa : MonoBehaviour
{
    [SerializeField]
    private float groundDistance;
    [SerializeField]
    private float force;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(this.transform.position, this.transform.position + Vector3.down * groundDistance, Color.magenta);
        
    }

    //Para físicas continuas
    private void FixedUpdate()
    {
        if (Physics.Raycast(this.transform.position, Vector3.down, groundDistance))
        {
            rb.AddForce(Vector3.up * force, ForceMode.Acceleration);
        }
        
    }
}
