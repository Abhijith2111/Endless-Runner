using UnityEngine;

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

    [SerializeField] private Rigidbody rigidBody3D;
    [SerializeField] private float jumpForce = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

 

    private void Jump()
    {
        rigidBody3D.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
    }
}
