using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text score;
    public Text lives;
    public int pScore;
    public int pLives;

    public Text highScore;


    // Use this for initialization
    void Start ()
    {
        pScore = 0;
        pLives = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        score.text = pScore.ToString();
        lives.text = pLives.ToString();

        if(pLives < 1)
        {
            SceneManager.LoadScene("EndScreenLost");
        }

        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();

        if (pScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", pScore);
        }
        

	}

    
}
