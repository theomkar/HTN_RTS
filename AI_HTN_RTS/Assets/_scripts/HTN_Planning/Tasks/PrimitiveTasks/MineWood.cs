using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineWood : Primitive_Task
{
    public MineWood(string tag) : base("MineWood")
    {
        op = new Mine(Resource.Wood, tag);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return (wp.WS_Player_Location == GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.T1Loc) &&
            !GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_isT1Empty) ||
             (wp.WS_Player_Location == GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.T2Loc) &&
             !GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_isT2Empty);
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Wood_Num += 5;
        return wp;
    }

}
