using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRockFromR2_Method : Compound_Task_Method
{
    public CollectRockFromR2_Method()
    {
        AddTask(new MoveToR2());
        AddTask(new MineRock("rock2"));
        AddTask(new MoveToBase());
    }

    public override bool Precondition(WorldProperties wp)
    {
        return !wp.WS_isR2Empty;
    }
}