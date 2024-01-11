using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int scoreValue;
    public Text score;

    // Start is called before the first frame update

    void Awake()
    {
        
    }

    void Start()
    {
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
       score.text = "Score: " + scoreValue.ToString();
    }

    public void AddScore(int amount)
    {
        scoreValue += amount;
    }


}
