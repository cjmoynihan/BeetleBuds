using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawnController : MonoBehaviour
{
    public List<IHazard> hazards;

    public int zoneWidth = 1;

    public int zoneHeight = 1;

    public void Start()
    {
        var choice = Random.Range(0, hazards.Count);
        var objectToSpawn = hazards[choice];
        Instantiate(objectToSpawn, transform.position + new Vector3(Random.Range(-zoneWidth, zoneWidth), Random.Range(-zoneHeight, zoneHeight), 0), new Quaternion());
    }
}
