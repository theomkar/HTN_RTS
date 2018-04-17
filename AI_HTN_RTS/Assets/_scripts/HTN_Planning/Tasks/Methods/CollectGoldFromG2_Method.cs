using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGoldFromG2_Method : Compound_Task_Method
{
    public CollectGoldFromG2_Method()
    {
        AddTask(new MoveToG2());
        AddTask(new MineGold("gold2"));
        AddTask(new MoveToBase());
    }

    public override bool Precondition(WorldProperties wp)
    {
        return !wp.WS_isG2Empty;
    }
}
