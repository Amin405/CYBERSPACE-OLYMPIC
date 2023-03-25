using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class WinCondition : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 60f; 
    [SerializeField] private TextMeshProUGUI timerText; // timer gui
    [SerializeField] private LeaningMenScript dudeScript; 
    [SerializeField] private GameObject dude; // "dude" GameObject

    private bool hasWon = false;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (!hasWon)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }

            if (timeRemaining <= 0f)
            {
                GameOver(false);
            }
            else if (!dude.activeInHierarchy)
            {
                ResetGame();
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Win()
    {
        if (!gameOver)
        {
            hasWon = true;
            timerText.text = "Win";
        }
    }

    private void GameOver(bool isWin)
    {
        gameOver = true;
        timerText.text = isWin ? "Win" : "Fail";
    }

    private void ResetGame()
    {
        dude.transform.position = dudeScript.initialPosition;
        dudeScript.Reset();
        dude.SetActive(true);
    }
}