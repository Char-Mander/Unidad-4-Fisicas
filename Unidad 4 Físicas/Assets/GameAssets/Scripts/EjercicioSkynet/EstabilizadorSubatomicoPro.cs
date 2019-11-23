using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstabilizadorSubatomicoPro : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float slerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotación eje z con izq y der
        transform.Rotate(-transform.forward * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.Self);
        //Rotación eje x con up y down
        transform.Rotate(transform.right * rotationSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.Self);

        //Propulsión
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 direMov = transform.forward;
            direMov.y = 0; // Evita que la nave salga volando
            transform.position += direMov * speed * Time.deltaTime;
        }

        //Estabilizador
        transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0), slerpSpeed);
    }

}
