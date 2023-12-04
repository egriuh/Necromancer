using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerScript : MonoBehaviour
{
    // Variables 
    private Rigidbody playerRb;
    public Animator animator;

    public bool isOnGround = true;
    public bool isRunning;

    public float speed;
    public float turnSpeed;
    public float horizontalInput;
    public float verticalInput;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation + Turning
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        // Moving Forward
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        animator.SetFloat("verticalInput", Mathf.Abs(verticalInput));

        // Running
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            speed = 60;
        }
        else
        {
            isRunning = false;
            speed = 10;
        }
        animator.SetBool("isRunning", isRunning);

        // Gather
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("gathering");
        }
    }

}
