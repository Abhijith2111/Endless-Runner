using UnityEngine;
using UnityEngine.Rendering;

public class SegmentGenerator : MonoBehaviour{

    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    void Start (){
        for (int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }
}