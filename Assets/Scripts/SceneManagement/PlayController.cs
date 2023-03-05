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
        floors = new List<string>();
        var floorPaths = Directory.GetDirectories("Assets/Scenes/Floors");

        foreach(var floorPath in floorPaths)
        {
            FloorController loadedFloor = new FloorController(floorPath);
            var floorName = new DirectoryInfo(floorPath).Name;
            floorsMap.Add(floorName, loadedFloor);
            floors.Add(floorName);
        }
    }

    public void LoadNextLevel()
    {
        var floorName = floors[currentFloorIndex];
        currentFloor = floorsMap[floorName];
        currentFloor.NextRoom();
    }

    public void Next()
    {
        currentFloor.NextRoom();
    }
}
