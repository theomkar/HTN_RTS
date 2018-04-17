using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToR1 : Primitive_Task
{
    public MoveToR1() : base("MoveToR1")
    {
        op = new MoveTo(Location.R1Loc);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return wp.WS_isPlayer_Free;
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Location = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.R1Loc);
        return wp;
    }
}
