using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int zoneHeight = 3;
    public int zoneWidth = 3;
    public int numToSpawn = 1;
    public int spawnValue = 1;

    public void SpawnEnemy()
    {
        Instantiate(objectToSpawn, new Vector3(Random.Range(-zoneWidth, zoneWidth), Random.Range(-zoneHeight, zoneHeight), 0), new Quaternion());
    }
}
