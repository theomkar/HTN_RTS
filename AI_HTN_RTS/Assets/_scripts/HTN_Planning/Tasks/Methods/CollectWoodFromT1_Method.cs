using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWoodFromT1_Method : Compound_Task_Method
{
    public CollectWoodFromT1_Method()
    {
        AddTask(new MoveToT1());
        AddTask(new MineWood("wood1"));
        AddTask(new MoveToBase());
    }

    public override bool Precondition(WorldProperties wp)
    {
        return !wp.WS_isT1Empty;
    }
}
