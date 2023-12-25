using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private float jumpForce = 5;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //If player pressed space key and is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("jump");
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Checking if player is on the ground
        if(collision.gameObject.name=="Path")
        {
            isGrounded = true;
        }
    }
}
