using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayController
{
    private List<string> floors;
    private Dictionary<string, FloorController> floorsMap;
    private readonly int ROOMS_PER_FLOOR = 3;
    private int currentFloorIndex = 0;
    private FloorController currentFloor;

    public PlayController()
    {
        floorsMap = new Dictionary<string, FloorController>();

        floors = new List<string>
        {
            "FirstFloor"
        };

        foreach(var floor in floors)
        {
            FloorController loadedFloor = new FloorController($"Assets\\Scenes\\{floor}");
            floorsMap.Add(floor, loadedFloor);
        }
    }

    public void LoadNextLevel()
    {
        var floorName = floors[currentFloorIndex];
        currentFloor = floorsMap[floorName];
        currentFloor.NextRoom();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
