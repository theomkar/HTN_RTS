using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWood : Compound_Task
{
    public CollectWood() : base("CollectWood")
    {
        AddMethod(new CollectWoodFromT1_Method());
        AddMethod(new CollectWoodFromT2_Method());
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Wood_Num += 5;
        return wp;
    }
}
