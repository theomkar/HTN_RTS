using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToT2 : Primitive_Task
{
    public MoveToT2() : base("MoveToT2")
    {
        op = new MoveTo(Location.T2Loc);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return wp.WS_isPlayer_Free;
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Location = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.T2Loc);
        return wp;
    }
}
