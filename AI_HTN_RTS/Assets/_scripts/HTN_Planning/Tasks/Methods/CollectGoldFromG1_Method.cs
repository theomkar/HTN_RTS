using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGoldFromG1_Method : Compound_Task_Method
{
    public CollectGoldFromG1_Method()
    {
        AddTask(new MoveToG1());
        AddTask(new MineGold("gold1"));
        AddTask(new MoveToBase());
    }

    public override bool Precondition(WorldProperties wp)
    {
        return !wp.WS_isG1Empty;
    }
}
