using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float shootForce;
    [SerializeField]
    private GameObject bulletPref;
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private Transform parteArriba;
    [SerializeField]
    private Transform posiDis;
    [SerializeField]
    bool isKyle=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Girar a los lados
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        //Girar para arriba
        Vector3 rotationVec = Vector3.left * rotateSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        parteArriba.Rotate(rotationVec);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        //Instanciar bullet
        GameObject bullet = Instantiate(bulletPref, posiDis.position, posiDis.rotation);
        if (!isKyle)
        {
            //Aplicar fuerza a bullet
            bullet.GetComponent<Rigidbody>().AddForce(posiDis.forward * shootForce, ForceMode.Impulse);
        }
        else
        {
            Rigidbody[] rigidbodies = bullet.GetComponentsInChildren<Rigidbody>();
            foreach(Rigidbody rb in rigidbodies)
            {
                rb.AddForce(posiDis.forward * shootForce, ForceMode.Impulse);
            }
        }
        //Destruir la bala si no impacta con nada
        Destroy(bullet, 15);
        Destroy(Instantiate(particle, posiDis.position, posiDis.rotation), 3);
    }
}
