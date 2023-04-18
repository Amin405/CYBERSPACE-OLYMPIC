using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDisplayController : MonoBehaviour
{
    public GameObject player;
    public float firstLlevelUpPositionX = 39.5f;
    public float secondLevelUpPositionX = 108.2f;
    public float resetPositionX = 0f;
    private int currentLevel = 1;
    private TextMeshProUGUI levelDisplayText;

    // Start is called before the first frame update
    void Start()
    {
        levelDisplayText = GetComponent<TextMeshProUGUI>();
        UpdateLevelDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= firstLlevelUpPositionX && currentLevel == 1)
        {
            currentLevel = 2;
            UpdateLevelDisplay();
        }
        if (player.transform.position.x >= secondLevelUpPositionX && currentLevel == 2)
        {
            currentLevel = 3;
            UpdateLevelDisplay();
        }
        
        // Reset the level when the player is back at the beginning
        if (player.transform.position.x <= resetPositionX)
        {
            currentLevel = 1;
            UpdateLevelDisplay();
        }
    }

    private void UpdateLevelDisplay()
    {
        levelDisplayText.text = "Level: " + currentLevel;
    }
}