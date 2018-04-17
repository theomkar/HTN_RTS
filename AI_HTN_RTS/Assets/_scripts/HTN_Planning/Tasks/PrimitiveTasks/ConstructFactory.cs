using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructFactory : Primitive_Task {

    public ConstructFactory() : base("ConstructFactory")
    {
        op = new Construct(Buildings.Factory);
    }

    public override bool Precondition(WorldProperties wp)
    {
        return GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_Player_Gold_Num >= 5 &&
            GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_Player_Rock_Num >= 5 &&
            GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_Player_Wood_Num >= 5;
    }

    public override WorldProperties Effect(WorldProperties wp)
    {
        wp.WS_Factory_Num += 1;
        return wp;
    }
}
