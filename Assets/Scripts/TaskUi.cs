using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskUi : MonoBehaviour
{
    public TextMeshProUGUI taskText;

    public void SetTaskText(string taskContent)
    {
        taskText.text = taskContent;
    }
}
