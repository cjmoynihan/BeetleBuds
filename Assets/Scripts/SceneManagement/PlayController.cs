using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayController
{
    private List<IFloor> floors = new List<IFloor>
    {
        new FirstFloor()
    };
    private int currentFloorIndex = 0;
    private IFloor currentFloor;

    public void LoadNextLevel()
    {
        currentFloor = floors[currentFloorIndex];
        Next();
    }

    public void Next()
    {
        currentFloor.LoadNextRoom();
    }
}
