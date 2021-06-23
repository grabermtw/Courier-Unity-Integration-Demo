/*
 *  This script handles the sending of notifications via Courier
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class Notifications : MonoBehaviour
{

    public TMP_InputField nameInput;
    public TMP_InputField emailInput;
    public TMP_InputField phoneInput;
    public TMP_InputField memoInput;
    private GameManager gameManager;

    const string EVENT_ID = "";
    const string AUTH_KEY = "";

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void Submit()
    {
        StartCoroutine(SendNotification());
    }

    private IEnumerator SendNotification()
    {
        WWWForm form = new WWWForm();
        form.AddField("event", EVENT_ID);
        form.AddField("recipient", nameInput.text);
        form.AddField("override", "{}");
        form.AddField("data", "{\"playerName\":\"" + nameInput.text + "\"," +
                              "\"score\":" + gameManager.GetScore() + "," + 
                              "\"memo\":\"" + memoInput.text + "\"}");
        form.AddField("profile", "{\"email\":\"" + emailInput.text + "\"," +
                                    "\"phone_number\":\"" + phoneInput.text + "\"}");
        using (UnityWebRequest www = UnityWebRequest.Post("https://api.courier.com/send", form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + AUTH_KEY);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                // reload the scene to play again
                SceneManager.LoadScene(0);
            }
        }
    }
}
