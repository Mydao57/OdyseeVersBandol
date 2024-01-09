using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderBoardManager : MonoBehaviour
{
    public Leaderboard leaderboard;
    void Start()
    {
    }

    void Update()
    {

    }

    IEnumerator CallLeaderboard(Action<IEnumerable<Score>> callback)
    {
        string apiUrl = "https://localhost:7104/LeaderBoard";

        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                string jsonResponse = www.downloadHandler.text;

                leaderboard = JsonUtility.FromJson<Leaderboard>(jsonResponse);
                foreach (Score score in leaderboard.scores)
                {
                    Debug.Log("Points: " + score.points + ", Name: " + score.name);
                }

                // Invoke the callback with the result
                callback?.Invoke(leaderboard.scores);
            }
        }
    }

    public void GetLeaderboard(Action<IEnumerable<Score>> callback)
    {
        StartCoroutine(CallLeaderboard(callback));
    }




}
