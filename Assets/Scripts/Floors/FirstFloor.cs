using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloor : IFloor
{
    public List<string> rooms = new List<string>();

    public override List<string> Rooms
    {
        get
        {
            if (rooms.Count == 0)
            {
                for(int i = 3; i < 13; i++)
                {
                    rooms.Add($"Variant {i}");
                }
            }
            return rooms;
        }
    }

    public override string Name => "Easy As Beans";

    public override List<string> BossRooms => new List<string>
    {
        "BigBoss"
    };

    public override int RoomsPerRun => 5;

    public override int StartingDifficulty => 3;

    public override int IncrementalDifficulty => 3;

    public override string Shop => "ShopFloor";
}
