using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public AudioSource DingSFX;
    public AudioSource GameOverSFX;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;




    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        Debug.Log("Score increased");
        DingSFX.Play();
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();

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
        PlayGameOverSFX();
    }

    public void PlayGameOverSFX()
    {
        GameOverSFX.Play();
        Debug.Log("Sound played");
    }
}
