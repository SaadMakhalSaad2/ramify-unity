using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    public TaskUi taskUi;
    public static TaskManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public TaskManager()
    {
        this.tasks = GenerateTasks();
    }

    public void DisplayTask(int index)
    {
        taskUi.SetTaskText(tasks[index].text);
    }

    private List<Task> GenerateTasks()
    {
        Task task1 = new Task("Go to tc", TaskType.VISIT_BUILDING, BuildingTag.TC);
        Task task3 = new Task("Say hi to a RAM", TaskType.TALK_TO_NPC);
        Task task2 = new Task("Go to the library", TaskType.TALK_TO_NPC, BuildingTag.LIBRARY);
        List<Task> tasks = new List<Task>();
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        return tasks;
    }

    public void CompelteTask(Task task)
    {
        Debug.Log("completing " + task.text + " task");
        GameManager.instance.playerHealth.Heal(5);
    }

    public List<Task> GetTasksForTargetBuilding(BuildingTag tag)
    {
        List<Task> tasksNeeded = new List<Task>();
        foreach (Task t in tasks)
        {
            if (t.targetBuilding == tag)
                tasksNeeded.Add(t);
        }
        return tasksNeeded;
    }
}

public class Task
{
    public string id;
    public string text;
    public int energyPoints;
    public int lovePoints;
    public TaskType type;

    public BuildingTag targetBuilding;

    public Task(string text, TaskType type)
    {
        this.id = System.Guid.NewGuid().ToString();
        this.text = text;
        this.type = type;
    }

    public Task(string text, TaskType type, BuildingTag tag)
    {
        this.id = System.Guid.NewGuid().ToString();
        this.text = text;
        this.type = type;
        this.targetBuilding = tag;
    }
}
