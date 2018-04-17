using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Task_Operator
{
    Resource ResourceType;
    float currentTime;
    float completeTime;
    string tagname;

    public Mine(Resource resource, string tag)
    {
        ResourceType = resource;
        currentTime = 0.0f;
        completeTime = 2.0f;
        tagname = tag;
    }

    public override ExecutionStatus Execute()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= completeTime)
        {
            Debug.Log("Mine " + ResourceType.ToString() + " Success");
            Vector3 player_loc = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty().WS_Player_Location;
            GameObject.Destroy(GameObject.FindGameObjectWithTag(tagname));
            return ExecutionStatus.Success;
        }
        return ExecutionStatus.Running;
    }

}
