using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private float radio;
    [SerializeField]
    private float exploforce;

    private bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasExploded)
        {
            ApplyExplosion();
            hasExploded = true;
        }
    }

    public void ApplyExplosion()
    {
        Rigidbody[] rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in rigidBodies)
        {
            rb.AddExplosionForce(exploforce, transform.position, radio, 10, ForceMode.Impulse); 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
