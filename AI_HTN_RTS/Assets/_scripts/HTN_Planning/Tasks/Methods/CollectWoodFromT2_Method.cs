using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWoodFromT2_Method : Compound_Task_Method
{
    public CollectWoodFromT2_Method()
    {
        AddTask(new MoveToT2());
        AddTask(new MineWood("wood2"));
        AddTask(new MoveToBase());
    }

    public override bool Precondition(WorldProperties wp)
    {
        return !wp.WS_isT2Empty;
    }
}

