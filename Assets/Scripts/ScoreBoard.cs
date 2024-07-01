using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private Text finalScoreText; // Reference to the Text component for displaying the final score

    void Start()
    {
        // Display the final score at the start
        DisplayFinalScore();
    }

    // Method to display the final score
    public void DisplayFinalScore()
    {
        // Get the current score from the GameManager
        int finalScore = GameManager.inst.GetScore();

        // Check if the final score is zero and update the text component accordingly
        if (finalScore == 0)
        {
            finalScoreText.text = "Final Score: 0";
        }
        else
        {
            finalScoreText.text = "Final Score: " + finalScore;
        }
    }
}