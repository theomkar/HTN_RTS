using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToG2 : Primitive_Task
{
    public MoveToG2() : base("MoveToG2")
    {
        op = new MoveTo(Location.G2Loc);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return wp.WS_isPlayer_Free;
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Location = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.G2Loc);
        return wp;
    }
}
