using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour
{
    public List<GameObject> grass;
    public List<GameObject> rocks;

    public int zoneHeight = 5;
    public int zoneWidth = 8;
    public int numGrassToSpawn = 10;
    public int numRocksToSpawn = 4;

    public void Start()
    {
        for (int i = 0; i < numGrassToSpawn; i++)
        {
            var choice = Random.Range(0, grass.Count);
            var objectToSpawn = grass[choice];
            Instantiate(objectToSpawn, transform.position + new Vector3(Random.Range(-zoneWidth, zoneWidth), Random.Range(-zoneHeight, zoneHeight), 0), new Quaternion());
        }
        for (int i = 0; i < numRocksToSpawn; i++)
        {
            var choice = Random.Range(0, grass.Count);
            var objectToSpawn = grass[choice];
            Instantiate(objectToSpawn, transform.position + new Vector3(Random.Range(-zoneWidth, zoneWidth), Random.Range(-zoneHeight, zoneHeight), 0), new Quaternion());
        }
    }
}
