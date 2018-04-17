using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExecutionStatus
{
    Success,
    Failure,
    Running
}

public abstract class Task_Operator
{
    public abstract ExecutionStatus Execute();
    public virtual void Reset() { }
}
