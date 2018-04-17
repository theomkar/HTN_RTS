using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTN_Domain : MonoBehaviour
{
    List<HTN_Task> allTask = new List<HTN_Task>();

    void Start()
    {
        allTask.Add(new CollectGold());
        allTask.Add(new CollectRock());
        allTask.Add(new CollectWood());
    }

    public List<HTN_Task> GetAllTask() { return allTask; }
    public HTN_Task GetTask(int index) { return allTask[index]; }
}
