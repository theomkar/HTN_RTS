using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectRock : Compound_Task
{
    public CollectRock() : base("CollectRock")
    {
        AddMethod(new CollectRockFromR1_Method());
        AddMethod(new CollectRockFromR2_Method());
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Rock_Num += 5;
        return wp;
    }
}
