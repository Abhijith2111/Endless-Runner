using UnityEngine;

public class OOF : MonoBehaviour
{
    [SerializeField] GameObject Player1;
    void OnTriggerEnter(Collider other)
    {
        Player1.GetComponent<PlayerMovment>().enabled = false;
    }
}
