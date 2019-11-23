using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaMoab : MonoBehaviour
{
    [SerializeField]
    private float timer;
    [SerializeField]
    private float radio;
    [SerializeField]
    private float forceExplo;
    [SerializeField]
    private GameObject exploParticle;
    [SerializeField]
    private LayerMask lm;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TiempoDeExplosion());
    }

    IEnumerator TiempoDeExplosion()
    {
        yield return new WaitForSeconds(timer);
        Explosion();
    }

    public void Explosion()
    {
        Destroy(Instantiate(exploParticle, transform.position, Quaternion.identity), 3);
        Collider[] colEnemies = Physics.OverlapSphere(transform.position, radio, lm);
        foreach (Collider colEnemy in colEnemies)
        {
            if(colEnemy.GetComponent<Rigidbody>() != null)
            {
                Vector3 direBombaToEnemy = (colEnemy.transform.position - transform.position).normalized;
                RaycastHit hitInfo;
                if (Physics.Raycast(transform.position, direBombaToEnemy, out hitInfo))
                {
                    //Para saber si el objeto con el que choca primero es el enemigo
                    if (hitInfo.collider.gameObject == colEnemy.gameObject)
                    {
                        colEnemy.GetComponent<Rigidbody>().AddExplosionForce(forceExplo, transform.position, radio, 2, ForceMode.VelocityChange);
                        Destroy(colEnemy.gameObject, 5);
                    }
                }
            }
        }

        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
