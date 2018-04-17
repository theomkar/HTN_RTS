using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildFactory : Compound_Task
{

    public BuildFactory() : base("BuildFactory")
    {
        AddMethod(new CollectGoldFromG1_Method());
        AddMethod(new CollectGoldFromG2_Method());
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Factory_Num += 1;
        return wp;
    }
}
