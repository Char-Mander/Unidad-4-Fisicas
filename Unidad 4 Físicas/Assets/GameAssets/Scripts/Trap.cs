using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("Colision onTriggerEnter");
            Destroy(Instantiate(particle, this.transform.position, transform.rotation), 5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("Colision onCollisionEnter");
            Destroy(Instantiate(particle, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), transform.rotation), 5);
        }
    }
}
