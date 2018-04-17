using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGold : Primitive_Task
{
    public MineGold(string tag) : base("MineGold")
    {
        op = new Mine(Resource.Gold, tag);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return (wp.WS_Player_Location == GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.G1Loc) &&
            !GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_isG1Empty) ||
            (wp.WS_Player_Location == GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(Location.G2Loc) &&
            !GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_isG2Empty);
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Player_Gold_Num += 5;
        return wp;
    }

}
