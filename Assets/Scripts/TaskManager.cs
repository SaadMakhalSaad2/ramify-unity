using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    public TaskUi taskUi;

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
        Task task1 = new Task("Go to tc", TaskType.VISIT_BUILDING);
        Task task3 = new Task("Say hi to a RAM", TaskType.TALK_TO_NPC);
        Task task2 = new Task("Go to the library", TaskType.TALK_TO_NPC);
        List<Task> tasks = new List<Task>();
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        return tasks;
    }

    public void CompelteTask(Task task)
    {
        Debug.Log("completing " + task.text + " task");
    }
}

public class Task
{
    public string text;
    public int energyPoints;
    public int lovePoints;
    public TaskType type;

    public string targetBuilding;

    public Task(string text, TaskType type)
    {
        this.text = text;
        this.type = type;
    }
}
