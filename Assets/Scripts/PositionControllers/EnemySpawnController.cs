using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public List<GameObject> enemies;
    public int zoneHeight = 3;
    public int zoneWidth = 3;

    public int SpawnEnemy()
    {
        var choice = Random.Range(0, enemies.Count);
        var objectToSpawn = enemies[choice];
        Instantiate(objectToSpawn, transform.position + new Vector3(Random.Range(-zoneWidth, zoneWidth), Random.Range(-zoneHeight, zoneHeight), 0), new Quaternion());
        return objectToSpawn.GetComponent<EnemyTypes.EnemyBehavior>().SpawnValue;
    }
}
