using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFisico : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        /*Vector3 currentPos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {//Movimiento físicas
            Vector3 dirMov = transform.forward;
            Vector3 destPos = currentPos +  (dirMov * speed * Time.deltaTime);
            //Mueve el rigid body a la posición que le digamos
            rb.MovePosition(destPos);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
        //Movimiento físicas
            Vector3 dirMov = -transform.forward;
            Vector3 destPos = currentPos + (dirMov * speed * Time.deltaTime);
            //Mueve el rigid body a la posición que le digamos
            rb.MovePosition(destPos);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
           
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

        }*/

        //Rotación físicas
        /*
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            Vector3 rotacionEje = Vector3.up;
            Quaternion nextRotation = Quaternion.Euler(currentRotation + rotacionEje * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }*/

        //Movimiento físicas
        //Posición actual + posición avance 
        rb.MovePosition(transform.position +
            transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
        //Rotación físicas
        //Rotación actual + rotación avance 
        rb.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles +
            Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
    }
}
