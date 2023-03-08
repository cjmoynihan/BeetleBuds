using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorController
{
    private List<string> roomsPossible;
    private string currentRoom;

    public FloorController(string floorPath)
    {
        var roomPaths = Directory.GetFiles($"{floorPath}").Where(x => x.EndsWith(".unity")).Select(x => x.Split(".")[0].Trim()).ToList();
        roomsPossible = roomPaths.Select(x => new DirectoryInfo(x).Name).ToList();
    }

    private string ChooseRoom()
    {
        var roomIndex = Random.Range(0, roomsPossible.Count);
        currentRoom = roomsPossible[roomIndex];
        roomsPossible.RemoveAt(roomIndex);
        return currentRoom;
    }

    public void NextRoom()
    {
        var roomChoice = ChooseRoom();
        SceneManager.LoadScene(roomChoice);
        currentRoom = roomChoice;
    }
}
