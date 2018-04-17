using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compound_Task : HTN_Task
{
    // Variables
    protected List<Compound_Task_Method> m_Method = new List<Compound_Task_Method>();
    protected int IndexofMethod = 0;

    // Constructor
    protected Compound_Task(string name)
    {
        m_Name = name;
        m_Type = TaskType.Type_CompoundTask;
    }

    public override void Reset()
    {
        for (int i = 0; i < m_Method.Count; ++i)
        {
            m_Method[i].IndexofTask = 0;
        }
        IndexofMethod = 0;
    }

    public void AddMethod(Compound_Task_Method method)
    {
        m_Method.Add(method);
    }

    public override ExecutionStatus Run()
    {
        ExecutionStatus method_result = ExecutionStatus.Failure;
        if ((!GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().CheckSensorChange() && m_Status == ExecutionStatus.Running) || m_Method[IndexofMethod].Precondition(GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty()))
        {
            ExecutionStatus task_result = m_Method[IndexofMethod].GetSubTask().Run();
            if (task_result == ExecutionStatus.Success)
            {
                ++m_Method[IndexofMethod].IndexofTask;

                if (m_Method[IndexofMethod].IndexofTask >= m_Method[IndexofMethod].GetSubTasks().Count)
                    method_result = ExecutionStatus.Success;
                else
                    method_result = ExecutionStatus.Running;
            }
            else if (task_result == ExecutionStatus.Running)
                method_result = ExecutionStatus.Running;
            else
            {
                ++IndexofMethod;
                if (IndexofMethod >= m_Method.Count)
                    method_result = ExecutionStatus.Failure;
            }
        }
        m_Status = method_result;
        return method_result;
    }

    public Compound_Task_Method GetSatisfiedMethod(WorldProperties wp)
    {
        for (int i = 0; i < m_Method.Count; ++i)
        {
            if (m_Method[i].Precondition(wp))
                return m_Method[i];
        }
        return null;
    }

    

}
