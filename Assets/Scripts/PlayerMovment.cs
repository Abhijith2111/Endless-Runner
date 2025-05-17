using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PlayerMovment : MonoBehaviour
{

    public float playerSpeed = 10;
    public float horizontalSpeed = 10;
    public float rightLimit = 6;
    public float leftLimit = -6;

    public float speedMultiplier;
    public float speedIncr;
    private float speedCount;
    private float playerHalfHeight;

    [SerializeField] Rigidbody rb;

    [SerializeField] float jumpForce = 50f;
    [SerializeField] LayerMask groundMask;

    // invincibility

    private bool isInvincible = false;
    private float invincibilityLeft = 0f;

    // Double jump

    private bool canDoubleJump = false;
    private bool doubleJumpActive = false;
    private float doubleJumpTimer = 0f;
    private float doubleJumpDuration = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        /*
         * Dude cant go right
         * he jumps too high
         */ 
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward *Time.deltaTime * playerSpeed);
        if(transform.position.x > speedCount)
        {
            speedCount += speedIncr;

            speedIncr = speedIncr * speedMultiplier;
            playerSpeed = playerSpeed * speedMultiplier;
        }



        if (Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.transform.position.z > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime  * playerSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (this.gameObject.transform.position.z < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * playerSpeed);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }


        if (isInvincible)
        {
            invincibilityLeft -= Time.deltaTime;
            if(invincibilityLeft <= 0)
            {
                isInvincible = false;
            }
        }

        isGrounded = Physics.Raycast(transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true;
            }
            else if (canDoubleJump && doubleJumpActive)
            {
                Jump();
                canDoubleJump = false;
            }
        }

        if (doubleJumpActive)
        {
            doubleJumpTimer -= Time.deltaTime;
            if (doubleJumpTimer <= 0f)
            {
                doubleJumpActive = false;
            }
        }

    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);

        //double jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void ActivateInvincibility(float duration)
    {
        isInvincible = true;
        invincibilityLeft = duration;
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InvincibilityPickup"))
        {
            ActivateInvincibility(5f);
            Destroy(other.gameObject);
        }
    }

    public void ActivateDoubleJump()
    {
        doubleJumpActive = true;
        doubleJumpTimer = doubleJumpDuration;
    }
}
