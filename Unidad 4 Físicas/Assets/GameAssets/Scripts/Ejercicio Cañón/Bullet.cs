using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int numRebotes=3;
    [SerializeField]
    private GameObject particleHit;
    [SerializeField]
    private GameObject particleDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        numRebotes--;
        Destroy(Instantiate(particleHit, collision.contacts[0].point, Quaternion.Euler(collision.contacts[0].normal)), 3);
        if (numRebotes <=0)
        {
            Destroy(Instantiate(particleDestroy, collision.contacts[0].point, Quaternion.Euler(collision.contacts[0].normal)), 3);
            Destroy(this.gameObject);
        }
        
    }
}
