using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compound_Task_Method
{
    // Index
    public int IndexofTask = 0;

    // Subtasks
    protected List<HTN_Task> m_Subtask = new List<HTN_Task>();

    public List<HTN_Task> GetSubTasks() { return m_Subtask; }

    public HTN_Task GetSubTask() { return m_Subtask[IndexofTask]; }

    public HTN_Task GetSubTask(int index) { return m_Subtask[index]; }

    public void AddTask(HTN_Task task)
    {
        m_Subtask.Add(task);
    }

    // Precondition
    public virtual bool Precondition(WorldProperties wp) { return true; }
}
