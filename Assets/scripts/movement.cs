using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float gravity = 9.81f;
    
    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 velocity;
    
    private Vector3 curentVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        
        if (input.magnitude> 1f)
        {
            input.Normalize();
        }
        
        Vector3 MoveVectro = transform.TransformDirection(input);
        
        
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * 1.5f : speed;
        
        
        curentVelocity = Vector3.SmoothDamp(curentVelocity, MoveVectro * currentSpeed, ref velocity, 0.1f);
        controller.Move(curentVelocity * Time.deltaTime);
        
        Ray groundRay = new Ray(transform.position, Vector3.down);
        
        if(Physics.Raycast(groundRay, 1.1f))
        {
            curentVelocity.y = -2f;
            if (Input.GetKey(KeyCode.Space))
            {
                curentVelocity.y = jumpForce;
            }
        }
        else
        {
            curentVelocity.y -= gravity * 3.2f * Time.deltaTime;
        }
        controller.Move(curentVelocity * Time.deltaTime);
    }
}
