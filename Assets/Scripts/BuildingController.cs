using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour, Interactable
{
    [SerializeField]
    Dialog dialog;

    public void Interact()
    {
        CompleteVisitBuildingTask();
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }

    private void CompleteVisitBuildingTask()
    {
        List<Task> tasksToComplete = new List<Task>();
        foreach (Task t in GameManager.instance.taskManager.tasks)
        {
            if (t.type == TaskType.TALK_TO_NPC)
                tasksToComplete.Add(t);
        }
        if (tasksToComplete.Count != 0)
        {
            //for now just complete the first task of this type
            GameManager.instance.taskManager.CompelteTask(tasksToComplete[0]);
        }
    }
}
