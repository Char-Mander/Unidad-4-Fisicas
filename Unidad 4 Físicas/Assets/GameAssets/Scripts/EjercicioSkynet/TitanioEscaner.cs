using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanioEscaner : MonoBehaviour
{
    [SerializeField]
    private float detectionDistance = 5;
    [SerializeField]
    private LayerMask capasIgnoradas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayo = new Ray(this.transform.position, transform.forward);
        /*
         * Cambiar el color del rayo cuando colisione con algún objeto a una distancia determinada
        if (Physics.Raycast(rayo, detectionDistance))
        {
            DrawDetectionRay(Color.red, transform.position + transform.forward * detectionDistance);
        }
        else
        {
            DrawDetectionRay(Color.white, transform.position + transform.forward * detectionDistance);
        }*/

        /* Detectar con información
        RaycastHit hitInfo;
        if (Physics.Raycast(rayo, out hitInfo, detectionDistance))
        {
            if (hitInfo.collider.gameObject.tag == "Enemigo")
            {
                DrawDetectionRay(Color.red, hitInfo.point);
            }
            else
            {
                DrawDetectionRay(Color.green, hitInfo.point);
            }
        }*/


        /* Detectar enemigo ignorando muro
        RaycastHit hitInfo;
        if (Physics.Raycast(rayo, out hitInfo, detectionDistance, capasIgnoradas))
        {
            if (hitInfo.collider.gameObject.tag == "Enemigo")
            {
                DrawDetectionRay(Color.red, hitInfo.point);
            }
            else
            {
                DrawDetectionRay(Color.green, hitInfo.point);
            }
        }*/


         RaycastHit[] hitInfos = Physics.RaycastAll(rayo, detectionDistance, capasIgnoradas);
          float distancia = 0;
          foreach (RaycastHit hit in hitInfos){
              if(distancia < hit.distance)
              {
                  distancia = hit.distance;
              }
          }
          if (hitInfos.Length != 0) {
              //print("Tengo delante " + hitInfos.Length + " enemigos");
              Debug.DrawLine(this.transform.position, transform.position + transform.forward * distancia, Color.red);
          }

        //Physics.SphereCast(); //Lo mismo que Raycast pero usando una esfera
        //Physics.CapsuleCast(); //Lo mismo que Raycast pero usando una cápsula

    }

    void DrawDetectionRay(Color color, Vector3 destination)
    {
        Debug.DrawLine(this.transform.position, destination, color);
    }
}
