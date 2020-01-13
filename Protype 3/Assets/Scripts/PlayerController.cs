using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * 10 * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            {

            }
        }
    }
    // here is the first new reference to "other" this is where I am not sure how
    // to fix this since it appears that the reference is invalid how do I fix this?

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }   else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over Woody");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
