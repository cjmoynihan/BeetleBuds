using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class IFloor : ScriptableObject
{
    public abstract List<string> Rooms { get; }

    public abstract string Name { get; }

    public abstract List<string> BossRooms { get; }

    public abstract int RoomsPerRun { get; }

    public List<string> RoomsVisited { get;} = new List<string>();

    public int NumRoomsVisited { get; set; } = 0;

    public List<string> RoomsRemaining { get; set; } = new List<string>();

    public abstract int StartingDifficulty { get; }

    public abstract int IncrementalDifficulty { get; }

    public string ChooseRoom()
    {
        if (RoomsRemaining.Count == 0)
        {
            RoomsRemaining = Rooms.Select(x => x).ToList();
        }

        if (RoomsPerRun == RoomsVisited.Count)
        {
            return BossRooms[Random.Range(0,BossRooms.Count)];
        }

        var roomIndex = Random.Range(0, RoomsRemaining.Count);
        var currentRoom = RoomsRemaining[roomIndex];
        RoomsRemaining.RemoveAt(roomIndex);
        RoomsVisited.Add(currentRoom);

        return currentRoom;
    }

    public void LoadNextRoom()
    {
        var roomChoice = ChooseRoom();
        SceneManager.LoadScene(roomChoice);
    }
}
