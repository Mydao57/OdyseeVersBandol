using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public LeaderBoardManager leaderBoardManager;


    void Start()
    {
        leaderBoardManager = GameObject.Find("LeaderboardManager").GetComponent<LeaderBoardManager>();
        leaderBoardManager.GetLeaderboard(scores =>
        {
            // Convert the IEnumerable<Score> to an array
            Score[] scoreArray = scores.OrderByDescending(s => s.points).ToArray();

            for (int i = 0; i < scoreArray.Length; i++)
            {
                Score score = scoreArray[i];
                RowUI newRow = Instantiate(rowUI, transform);
                newRow.rank.text = (i + 1).ToString();
                newRow.name.text = score.name;
                newRow.score.text = score.points.ToString();
            }

            // Process the scores or update UI as needed
        });
    }

}
