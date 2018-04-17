using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTN_Planner : MonoBehaviour
{

    // Variables
    HTN_Task m_maintask;
    List<HTN_Task> TaskToProgress = new List<HTN_Task>();
    List<HTN_Task> FinalTask = new List<HTN_Task>();

    public void Plan()
    {
        FinalTask.Clear();
        // Copy 
        WorldProperties WS_Properties = GameObject.FindGameObjectWithTag("Singleton").GetComponent<WorldState_Sensor>().GetPlayerProperty();

        TaskToProgress.Add(m_maintask);

        while (TaskToProgress.Count > 0)
        {
            HTN_Task current_task = TaskToProgress[0];
            TaskToProgress.RemoveAt(0);

            if (current_task.GetTaskType() == TaskType.Type_CompoundTask)
            {
                Compound_Task_Method satisfied_method = ((Compound_Task)current_task).GetSatisfiedMethod(WS_Properties);
                if (satisfied_method != null)
                {
                    List<HTN_Task> subtasks = satisfied_method.GetSubTasks();
                    for (int i = subtasks.Count - 1; i >= 0; --i)
                        TaskToProgress.Insert(0, subtasks[i]);
                }
                else
                {

                }
            }
            else if (current_task.GetTaskType() == TaskType.Type_PrimitiveTask)
            {
                if (current_task.Precondition(WS_Properties))
                {
                    WS_Properties = current_task.Effect(WS_Properties);
                    FinalTask.Add(current_task);
                }
                else
                {

                }
            }

        }
    }

    public void SetMainTask(HTN_Task task) { m_maintask = task; }
    public List<HTN_Task> GetFinalTask() { return FinalTask; }
}
