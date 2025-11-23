using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LogicScript : MonoBehaviour
{
    public AudioSource DingSFX;
    public AudioSource GameOverSFX;
    public int playerScore;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]

    void Start()
    {
        HighScoreUpdate();
    }

    public void AddScore(int scoreToAdd)
    {
        Debug.Log("Score increased", scoreText);
        DingSFX.Play();
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        HighScoreUpdate();
    }

    public void HighScoreUpdate()
    {

        // Is there already a highscore?
        if (PlayerPrefs.HasKey("HighScore"))
        {
            // If there is, check if the current score is higher than the highscore
            if (playerScore > PlayerPrefs.GetInt("HighScore"))
            {
                Debug.Log("Highscore updated");
                // If it is, update the highscore
                PlayerPrefs.SetInt("HighScore", playerScore);
            }
        }
        else
        {
            // If there isn't, create a highscore
            PlayerPrefs.SetInt("HighScore", playerScore);
        }

        // Update TMP text
        finalScoreText.text = playerScore.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void RestartGame()
    {
        Debug.Log("Game restarted");

        // Looks for the name of the scene (aka. filename)
        // This gets the active scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        gameOverScreen.SetActive(true);
        finalScoreText.text = playerScore.ToString();
        PlayGameOverSFX();
        HighScoreUpdate();
    }

    public void PlayGameOverSFX()
    {
        GameOverSFX.Play();
        Debug.Log("Sound played");
    }
}
