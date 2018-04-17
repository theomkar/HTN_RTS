using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType
{
    Type_CompoundTask,
    Type_PrimitiveTask
}


public abstract class HTN_Task
{
    protected string m_Name;
    protected TaskType m_Type;
    protected ExecutionStatus m_Status = ExecutionStatus.Failure;

    public virtual string GetName() { return m_Name; }
    public virtual TaskType GetTaskType() { return m_Type; }

    public virtual void Reset() { }
    public virtual bool Precondition(WorldProperties wp) { return true; }
    public virtual WorldProperties Effect(WorldProperties wp) { return wp; }

    public abstract ExecutionStatus Run();
}
