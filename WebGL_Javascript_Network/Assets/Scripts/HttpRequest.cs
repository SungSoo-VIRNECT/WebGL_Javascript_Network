using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class HttpRequest : MonoBehaviour
{
    public string url;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(SendRequest);
    }

    void SendRequest()
    {
        StartCoroutine(SendRequestCoroutine());
    }

    IEnumerator SendRequestCoroutine()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("HTTP request successful");
                Debug.Log(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log("HTTP request failed: " + webRequest.error);
            }
        }
    }
}