using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score; //store score value
    public TextMeshProUGUI scoreText; //Refrence visual text UI element to change

    // This function rewards the player
    public void IncreaseScore(int amount)
    {
        score += amount; //Add amount to the score
        UpdateScoreText(); // Update the score UI text
    }
    // THis function penalizes the player
    public void DecreaseScore(int amount)
    {
        score -= amount; //Subtract amount from the score
        UpdateScoreText(); // Update the score UI text
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: "+ score;
    }
}
