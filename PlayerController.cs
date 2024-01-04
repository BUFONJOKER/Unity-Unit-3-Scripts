using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;

    private Animator playerAnimation;
    public float jumpForce = 10;
    public float gravityModifier;

    public bool isOnGround = false;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameOver == false)
        {
            // player jump 
            // add force use to apply force to rigid body An impulse is a large force applied instantly, as opposed to a continuous force.

            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle")){
            // death animation
            playerAnimation.SetBool("Death_b",true);
            playerAnimation.SetInteger("DeathType_int",1);
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
