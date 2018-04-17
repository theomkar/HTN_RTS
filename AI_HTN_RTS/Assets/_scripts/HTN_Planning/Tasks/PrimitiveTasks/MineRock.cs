using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineRock : Primitive_Task
{
    public MineRock(string tag) : base("MineRock")
    {
        op = new Mine(Resource.Rock, tag);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return (wp.WS_Player_Location == GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.R1Loc) &&
            !GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_isR1Empty) ||
            (wp.WS_Player_Location == GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.R2Loc) &&
            !GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_isR2Empty);
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Rock_Num += 5;
        return wp;
    }

}
