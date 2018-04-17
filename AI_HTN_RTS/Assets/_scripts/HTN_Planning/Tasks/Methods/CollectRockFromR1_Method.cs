using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRockFromR1_Method : Compound_Task_Method
{
    public CollectRockFromR1_Method()
    {
        AddTask(new MoveToR1());
        AddTask(new MineRock("rock1"));
        AddTask(new MoveToBase());
    }

    public override bool Precondition(WorldProperties wp)
    {
        return !wp.WS_isR1Empty;
    }
}
