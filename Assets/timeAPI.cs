using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class TimeAPI : MonoBehaviour
{
    public GameObject timeTextObject;

    //api here like weather, but no key needed, just lat and lon
    string url = "https://timeapi.io/api/time/current/coordinate?latitude=25.0330&longitude=121.5654";

    void Start()
    {
        Debug.Log("Hello");
        InvokeRepeating("GetTimeFromWeb", 2f, 900f); 
    }

    void GetTimeFromWeb()
    {
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error: " + webRequest.error);
            }
            else
            {
                string json = webRequest.downloadHandler.text;
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

                int startHour = json.IndexOf("\"hour\":");
                int endHour = json.IndexOf(",", startHour);
                string hour = json.Substring(startHour + 7, endHour - startHour - 7);
                int startMin = json.IndexOf("\"minute\":");
                int endMin = json.IndexOf(",", startMin);
                string minute = json.Substring(startMin + 9, endMin - startMin - 9);
                int startSec = json.IndexOf("\"seconds\":");
                int endSec = json.IndexOf(",", startSec);
                string seconds = json.Substring(startSec + 10, endSec - startSec - 10);

                string timeDisplay = hour.PadLeft(2,'0') + ":" + 
                                     minute.PadLeft(2,'0') + ":" + 
                                     seconds.PadLeft(2,'0');

                timeTextObject.GetComponent<TextMeshPro>().text = timeDisplay;
            }
        }
    }

    void Update() { }
}