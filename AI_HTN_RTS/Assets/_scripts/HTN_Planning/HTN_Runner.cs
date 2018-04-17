using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTN_Runner : MonoBehaviour {

    bool isCompleted = true;
    int indexofTask = 0;
    List<HTN_Task> RunningTask;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B Pressed");
            GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().SetWorldProperty_G1Empty(true);
            //GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().SetWorldProperty_PlayerLocation(Location.G1Loc);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Start");
            GameObject.FindGameObjectWithTag("Singleton").GetComponent<HTN_Planner>().SetMainTask(new CollectGold());
            GameObject.FindGameObjectWithTag("Singleton").GetComponent<HTN_Planner>().Plan();
            RunningTask = GameObject.FindGameObjectWithTag("Singleton").GetComponent<HTN_Planner>().GetFinalTask();
            if (RunningTask.Count > 0)
            {
                isCompleted = false;
                indexofTask = 0;
                Debug.Log("GetTask");
            }
            else
            {
                isCompleted = true;
                Debug.Log("No Plan Found");
            }
        }

        if (!isCompleted)
        {
            ExecutionStatus status = RunningTask[indexofTask].Run();
            if (status == ExecutionStatus.Success)
                ++indexofTask;
            else if (status == ExecutionStatus.Failure)
            {
                Debug.Log("Fail");
                GameObject.FindGameObjectWithTag("Singleton").GetComponent<HTN_Planner>().Plan();
                isCompleted = false;
                indexofTask = 0;
                RunningTask = GameObject.FindGameObjectWithTag("Singleton").GetComponent<HTN_Planner>().GetFinalTask();
            }
            if (indexofTask >= RunningTask.Count)
            {
                Debug.Log("Success");
                isCompleted = true;
            }
        }
	}
}
