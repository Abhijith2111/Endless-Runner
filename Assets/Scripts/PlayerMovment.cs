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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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


       
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);
    }



}
