using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class leaderBoardMan : MonoBehaviour
{
    public float distanceToTrigger = 2f;
    public KeyCode dialogueKey = KeyCode.E;
    public GameObject leaderboard;

    public Canvas LeaderBoardCanva;

    private bool isInRange = false;

    public void Start()
    {
        leaderboard.SetActive(false);
    }
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(dialogueKey))
        {
            leaderboard.SetActive(true);
            LeaderBoardCanva.gameObject.SetActive(false);

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LeaderBoardCanva.gameObject.SetActive(true);
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LeaderBoardCanva.gameObject.SetActive(false);

            leaderboard.SetActive(false);
            isInRange = false;
        }
    }

    public void CloseLeaderboard()
    {
        leaderboard.SetActive(false);

    }
}
