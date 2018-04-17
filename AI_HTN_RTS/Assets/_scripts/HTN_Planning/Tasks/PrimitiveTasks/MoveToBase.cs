using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBase : Primitive_Task
{
    public MoveToBase() : base("MoveToBase")
    {
        op = new MoveTo(Location.BaseLoc);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return wp.WS_isPlayer_Free;
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Location = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.BaseLoc);
        return wp;
    }
}
