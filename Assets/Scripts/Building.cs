using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, Interactable
{
    [SerializeField]
    Dialog dialog;

    [SerializeField]
    BuildingTag tag;

    public void Interact()
    {
        CompleteVisitBuildingTask();
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }

    private void CompleteVisitBuildingTask()
    {
        // List<Task> tasksToComplete = GameManager.instance.taskManager.GetTasksForTargetBuilding(
        //     this.tag
        // );
        // if (tasksToComplete.Count != 0)
        //     GameManager.instance.taskManager.CompelteTask(tasksToComplete[0]);
        Task taskToDisplay = GameManager.instance.taskManager.GetNextTask();
        if (taskToDisplay != null && taskToDisplay.targetBuilding == this.tag)
            GameManager.instance.taskManager.CompelteTask(taskToDisplay);

    }
}

public enum BuildingTag
{
    TC,
    LIBRARY
}
