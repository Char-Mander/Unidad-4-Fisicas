using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    CharacterController controller;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float gravity;
    Rigidbody rb;
    [SerializeField]
    private float pushForce;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = transform.forward * speed * Input.GetAxis("Vertical");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody bodyHit = hit.collider.gameObject.GetComponent<Rigidbody>();

        if(bodyHit == null || bodyHit.isKinematic)
        {
            return;
        }

        Vector3 pushVec = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        bodyHit.velocity = pushVec * pushForce;
    }
}
