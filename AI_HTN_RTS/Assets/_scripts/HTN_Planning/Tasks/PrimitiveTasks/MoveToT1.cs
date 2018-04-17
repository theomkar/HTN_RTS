using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToT1 : Primitive_Task
{
    public MoveToT1() : base("MoveToT1")
    {
        op = new MoveTo(Location.T1Loc);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return wp.WS_isPlayer_Free;
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Location = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.T1Loc);
        return wp;
    }
}
