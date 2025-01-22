using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Scoreboard : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text clockText;
    public float timePassed;
    
    public bool gameOver = false;
    public GameObject gameOverScreen; 
    public GameObject summonerObject;
    private spawn_balls spawnBallScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnBallScript = summonerObject.GetComponent<spawn_balls>();
        timePassed = 0f;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) return;
        
        timePassed += Time.deltaTime;
        clockText.text = "Clock: " + timePassed.ToString("F2");
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void EndGame()
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        gameOver = false;
        gameOverScreen.SetActive(false);
        score = 0;
        timePassed = 0f;
        spawnBallScript.ClearBalls();
        spawnBallScript.SpawnBall();
    }
}
