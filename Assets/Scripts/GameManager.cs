using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0; // The score variable to store the current score
    public static GameManager inst; // A static instance of GameManager for easy access
    [SerializeField] private Text scoreText; // The UI Text element to display the score

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Set the static instance to this instance of GameManager
        inst = this;

        // Initialize the score display
        UpdateScoreText();
    }

    // Method to increment the score
    public void IncrementScore()
    {
        // Increment the score
        score++;

        // Update the score display
        UpdateScoreText();
    }

    // Method to update the score text on the UI
    private void UpdateScoreText()
    {
        // Update the text component with the current score
        scoreText.text = "SCORE: " + score;
    }

    // Method to retrieve the current score
    public int GetScore()
    {
        // Return the current score
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        // This can be used to handle other updates if necessary
    }
}