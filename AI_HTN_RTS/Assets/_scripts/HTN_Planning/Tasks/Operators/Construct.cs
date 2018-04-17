using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construct : Task_Operator
{
    Buildings buildingType;
    float currentTime;
    float completeTime;
    public Construct(Buildings building)
    {
        buildingType = building;
        currentTime = 0.0f;
        completeTime = 3.0f;
    }

    public override ExecutionStatus Execute()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= completeTime)
        {
            Debug.Log("Build " + buildingType.ToString() + " Success");
            return ExecutionStatus.Success;
        }
        return ExecutionStatus.Running;
    }
}
