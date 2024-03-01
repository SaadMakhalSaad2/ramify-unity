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

    //Enahnace task selection and completion logic
    private void CompleteVisitBuildingTask()
    {
        List<Task> tasksToComplete = GameManager.instance.taskManager.GetTasksForTargetBuilding(tag);
        Debug.Log("found " + tasksToComplete[0] + " to complete");
        //GameManager.instance.taskManager.CompelteTask(tasksToComplete[0]);
    }
}

public enum BuildingTag
{
    TC,
    LIBRARY
}
