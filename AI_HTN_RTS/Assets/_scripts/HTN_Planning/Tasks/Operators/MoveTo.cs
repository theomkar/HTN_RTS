using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : Task_Operator
{
    Vector3 StartLocation;
    Vector3 TargetLocation;
    Location TargetLoc;
    public Vector3 GetTargetLocation() { return TargetLocation; }
    float currentTime;
    float completeTime;

    public MoveTo(Location index)
    {
        TargetLoc = index;
        TargetLocation = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetAbsoluteLocation(index);
        currentTime = 0.0f;
        completeTime = 5.0f;
    }

    public MoveTo(Vector3 location)
    {
        TargetLocation = location;
        currentTime = 0.0f;
        completeTime = 5.0f;
    }

    public override ExecutionStatus Execute()
    {
        if (currentTime == 0.0f)
            StartLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (currentTime <= completeTime)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = Vector3.Lerp(StartLocation, TargetLocation, currentTime / completeTime);
        }
        currentTime += Time.deltaTime;
        if (currentTime >= completeTime)
        {
            GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().SetWorldProperty_PlayerLocation(TargetLoc);
            Debug.Log(TargetLoc.ToString() + "Arrived");
            return ExecutionStatus.Success;
        }
        return ExecutionStatus.Running;
    }
}
