using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHighScoresScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    public void DeleteHighScores()
    {
        Debug.Log("Delete High Scores");
        PlayerPrefs.DeleteAll();
        logic.HighScoreUpdate();
    }

}
