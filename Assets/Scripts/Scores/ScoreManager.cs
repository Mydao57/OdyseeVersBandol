using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int scoreValue;
    Text score;

    // Start is called before the first frame update

    void Awake()
    {
        scoreValue = 0;

    }

    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }

    public void AddScore(int amount)
    {
        scoreValue += amount;
    }


}
