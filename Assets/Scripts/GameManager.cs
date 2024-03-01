using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CollectableManager collectableManager;
    public TaskManager taskManager;

    [SerializeField]
    public PlayerHealth playerHealth;

    [SerializeField]
    PlayerMovement playerMovement;

    GameState state;

//some stupid comment for testing version control push
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        collectableManager = GetComponent<CollectableManager>();

        taskManager = GetComponent<TaskManager>();
        taskManager.DisplayTask(0);
    }

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.DIALOG;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (state == GameState.DIALOG)
                state = GameState.FREE_ROAM;
        };
    }

    void Update()
    {
        if (state == GameState.FREE_ROAM)
        {
            playerMovement.HandleUpdate();
        }
        else if (state == GameState.DIALOG)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else { }
    }
}

public enum GameState
{
    FREE_ROAM,
    DIALOG,
    BATTLE
}

public enum TaskType
{
    VISIT_BUILDING,
    TALK_TO_NPC
}
