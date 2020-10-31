using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class SimpleCharacter : MonoBehaviour
{
    CharacterController characterController;
    public Camera cam;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector2 lastMousePos;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        lastMousePos = Mouse.current.position.ReadValue();
        cam.transform.localEulerAngles =Vector3.zero;
    }
    private float gravityForce = 0;
    private float jumpForce = 0;
    void Update()
    {
       
            // We are grounded, so recalculate
            // move direction directly from axes
            float side = (Keyboard.current.dKey.isPressed ? 1.0f : 0.0f);
            if (side == 0)
            {
                side = (Keyboard.current.aKey.isPressed ? -1.0f : 0.0f);
            }

            float forward = (Keyboard.current.wKey.isPressed ? 1.0f : 0.0f);
            if (forward == 0)
            {
                forward = (Keyboard.current.sKey.isPressed ? -1.0f : 0.0f);
            }

            moveDirection = new Vector3(side, 0.0f, forward);
            moveDirection *= speed;

      
        

        Quaternion q = Quaternion.Euler(transform.eulerAngles);
        moveDirection = q*moveDirection;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);


        if (isGrounded())
        {
        //    Debug.Log("grabity force =0" + Time.time);
            gravityForce = 0;
            moveDirection.x = moveDirection.z = moveDirection.y = 0;
            if (Keyboard.current.spaceKey.isPressed)
            {
                moveDirection.y = jumpSpeed;
                jumpForce = jumpSpeed;
            }
         
            characterController.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            //
            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
           
            gravityForce -= gravity * Time.deltaTime;
            gravityForce += jumpForce * Time.deltaTime;
            jumpForce -= gravity * Time.deltaTime;
            jumpForce = Mathf.Clamp(jumpForce, 0, 1000);
            characterController.Move(new Vector3(0,gravityForce,0) * Time.deltaTime);
        }

        //rotation
        Vector2 current = -Mouse.current.delta.ReadValue();


        //delta
        float deltaX = current.x;
        float deltaY = current.y;

        //
        transform.Rotate(new Vector3(0, 1, 0), -deltaX * Time.deltaTime*10.0f);

        lastMousePos = Mouse.current.position.ReadValue();

        //
        Vector3 euler = cam.transform.localEulerAngles;
        float currentPitch=cam.transform.localEulerAngles.x;
        float value = deltaY * Time.deltaTime*8.0f;

        currentPitch += value;

         if(value<0)
        {
            if(currentPitch>45.0f && currentPitch<315.0f)
            {
                currentPitch = 315.0f;
            }
        }
         else if(value >0)
        {
            if(currentPitch>45.0f && currentPitch<315.0f)
            {
                currentPitch = 45.0f;
            }
        }


        
        euler.x = currentPitch;
        cam.transform.localEulerAngles = euler;
    }

    private bool isGrounded()
    {
        Vector3 checkPos = transform.TransformPoint(characterController.center);
        float lengthCheck = characterController.height*0.5f + 0.08f;
        RaycastHit hit;
    //    Debug.DrawLine(checkPos, checkPos - new Vector3(0, lengthCheck, 0),Color.blue,10);
        if (Physics.SphereCast(checkPos, 0.3f, Vector3.down, out hit, lengthCheck))
        {
            return true;
        }
        return false;
    }
}