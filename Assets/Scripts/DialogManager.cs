using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    GameObject dialogBox;

    [SerializeField]
    public TextMeshProUGUI dialogText;

    [SerializeField]
    int lettersPerSecond;
    public event Action OnShowDialog;
    public event Action OnHideDialog;
    Dialog dialog;
    int currentline = 0;
    bool isTyping;
    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Z) && !isTyping)
        {
            Debug.Log(dialog.Lines[currentline]);

            ++currentline;
            if (currentline < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentline]));
            }
            else
            {
                HideDialog();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HideDialog();
        }
    }

    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";

        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }

    private void HideDialog()
    {
        dialogBox.SetActive(false);
        OnHideDialog?.Invoke();
        currentline = 0;
    }
}
