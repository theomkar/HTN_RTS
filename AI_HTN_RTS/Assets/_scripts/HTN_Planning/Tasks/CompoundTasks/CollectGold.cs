using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGold : Compound_Task
{
    public CollectGold() : base("CollectGold")
    {
        AddMethod(new CollectGoldFromG1_Method());
        AddMethod(new CollectGoldFromG2_Method());
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Gold_Num += 5;
        return wp;
    }
}
