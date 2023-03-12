using System;
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

    private bool shopVisited = false;

    public List<string> RoomsVisited { get;} = new List<string>();

    public int NumRoomsVisited { get; set; } = 0;

    public List<string> RoomsRemaining { get; set; } = new List<string>();

    public abstract int StartingDifficulty { get; }

    public abstract int IncrementalDifficulty { get; }

    public abstract string Shop { get; }

    public string ChooseRoom()
    {
        // Rounds up to the nearest whole number.
        if (RoomsPerRun - 2 == RoomsVisited.Count && !shopVisited)
        {
            shopVisited = true;
            return Shop;
        }

        if (RoomsRemaining.Count == 0)
        {
            RoomsRemaining = Rooms.Select(x => x).ToList();
        }

        if (RoomsPerRun == RoomsVisited.Count)
        {
            return BossRooms[UnityEngine.Random.Range(0,BossRooms.Count)];
        }

        var roomIndex = UnityEngine.Random.Range(0, RoomsRemaining.Count);
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
