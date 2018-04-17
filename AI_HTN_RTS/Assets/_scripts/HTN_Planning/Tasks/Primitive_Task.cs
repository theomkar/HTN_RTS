using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Primitive_Task : HTN_Task
{
    // Variables
    protected Task_Operator op;

    // Constructor
    protected Primitive_Task(string name)
    {
        m_Name = name;
        m_Type = TaskType.Type_PrimitiveTask;
    }

    // Run if precondition is true and cause effect when the operator succeed
    public override ExecutionStatus Run()
    {
        ExecutionStatus result = ExecutionStatus.Failure;
        if ((!GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().CheckSensorChange() && m_Status == ExecutionStatus.Running) || Precondition(GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty()))
        {
            result = op.Execute();
        }
        else
        {
            Reset();
        }
        m_Status = result;
        return result;
    }
}
