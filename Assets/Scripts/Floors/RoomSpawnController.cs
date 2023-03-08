using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomSpawnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var currentFloor = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>()._playController.currentFloor;
        int roomDifficulty = (currentFloor.RoomsVisited.Count()-1) * currentFloor.IncrementalDifficulty + currentFloor.StartingDifficulty;
        int accumulatedDifficulty = 0;
        var spawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn").Select(x => x.GetComponent<EnemySpawnController>()).ToList();
        int index = 0;
        while (accumulatedDifficulty < roomDifficulty)
        {
            bool spawnHere = 0 == Random.Range(0, spawnPoints.Count());
            if (!spawnHere) continue;

            var spawn = spawnPoints[index % spawnPoints.Count()];
            var spawnValue = spawn.spawnValue;
            accumulatedDifficulty += spawnValue;
            spawn.SpawnEnemy();
        }
    }

}
