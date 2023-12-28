using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private float jumpForce;
    private bool isGrounded;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        jumpForce = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("jump");
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Path")
        {
            isGrounded = true;
        }
    }
}
