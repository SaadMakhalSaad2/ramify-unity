using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class BackendConnection : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;

    void Start() { }

    public void Login()
    {
        LoginData requestData = new LoginData { email = email.text, password = password.text };
        string jsonData = JsonUtility.ToJson(requestData);
        StartCoroutine(EmailLogin("http://127.0.0.1:3000/v1/login", jsonData));
    }

    private IEnumerator EmailLogin(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Response: " + uwr.downloadHandler.text);
        }
    }
}

[System.Serializable]
public class LoginData
{
    public string email;
    public string password;
}
