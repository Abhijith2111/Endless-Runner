using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovment player = other.GetComponent<PlayerMovment>();
        if (player != null)
        {
            player.ActivateDoubleJump();
            Destroy(gameObject); // Remove the pickup from the scene
        }

    }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
