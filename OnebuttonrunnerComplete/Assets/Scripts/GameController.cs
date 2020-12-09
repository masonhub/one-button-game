using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject gameOverPanel;
    public Text scoreText;
    int score = 0;
    public Text bestText;
    public Text currentText;
    public GameObject newAlert;
    public GameObject player;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (player.transform.position.y < -7f)
        {
            GameOver();
        }


    }

    public void GameOver() {
        Invoke("ShowOverPanel", 2.0f);
    }

    void ShowOverPanel() {
        scoreText.gameObject.SetActive(false);

        if (score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
            newAlert.SetActive(true);
        }

        bestText.text = "Best Score : " + PlayerPrefs.GetInt("Best", 0).ToString();
        currentText.text = "Current Score : " + score.ToString();

        gameOverPanel.SetActive(true);
    }

    public void Restart() {
        Initiate.Fade(Application.loadedLevelName,Color.white,2.0f);
    }

    public void IncrementScore() {
        score++;
        scoreText.text = score.ToString();
    
    }

}
