using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToR2 : Primitive_Task
{
    public MoveToR2() : base("MoveToR2")
    {
        op = new MoveTo(Location.R2Loc);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return wp.WS_isPlayer_Free;
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Location = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.R2Loc);
        return wp;
    }
}
