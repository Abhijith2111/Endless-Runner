using UnityEngine;

public class SegmentStuff : MonoBehaviour
{

    SegmentGenerator segmentGenerator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        segmentGenerator = GameObject.FindObjectOfType<SegmentGenerator>();
    }

    private void OnTriggerExit(Collider other)
    {
        segmentGenerator.SpawnTile();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
