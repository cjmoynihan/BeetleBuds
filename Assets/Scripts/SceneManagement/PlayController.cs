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
        ScriptableObject.CreateInstance<FirstFloor>()
    };
    private int currentFloorIndex = 0;
    public IFloor currentFloor;

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
