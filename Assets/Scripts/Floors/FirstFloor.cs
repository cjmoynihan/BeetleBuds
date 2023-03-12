using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloor : IFloor
{
    public override List<string> Rooms => new List<string>{
        "BasicLevel",
        "TestingGrounds" 
    };

    public override string Name => "Easy As Beans";

    public override List<string> BossRooms => new List<string>
    {
        "BigBoss"
    };

    public override int RoomsPerRun => 5;

    public override int StartingDifficulty => 3;

    public override int IncrementalDifficulty => 3;

    public override string Shop => "FirstFloorShop";
}
