using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToG1 : Primitive_Task
{ 
    public MoveToG1() : base("MoveToG1")
    {
        op = new MoveTo(Location.G1Loc);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return wp.WS_isPlayer_Free;
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Location = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.G1Loc);
        return wp;
    }
}
