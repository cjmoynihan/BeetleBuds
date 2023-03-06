using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int zoneHeight = 3;
    public int zoneWidth = 3;
    public int numToSpawn = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            Instantiate(objectToSpawn, new Vector3(Random.Range(-zoneWidth, zoneWidth), Random.Range(-zoneHeight, zoneHeight), 0), new Quaternion());
        }
    }
}
