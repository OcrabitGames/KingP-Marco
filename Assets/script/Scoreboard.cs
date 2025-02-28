using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class Scoreboard : MonoBehaviour
{
    public int score = 0;
    public int nearMisses = 0;
    public TMP_Text scoreText;
    public TMP_Text clockText;
    public TMP_Text nearMissText;
    public float timePassed;
    
    public bool gameOver = false;
    public GameObject gameOverScreen; 
    private GameObject summonerObject;
    private PinMovement pinMovementScript;
    private spawn_balls spawnBallScript;
    private AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponents<AudioSource>()[0];
            
        scoreText = GameObject.Find("Canvas/ScorePanel/ScoreText").GetComponent<TMP_Text>(); 
        clockText = GameObject.Find("Canvas/Time Panel/Timer").GetComponent<TMP_Text>();
        nearMissText = GameObject.Find("Canvas/NearMissPanel/NearMiss").GetComponent<TMP_Text>();
        
        pinMovementScript = GetComponent<PinMovement>();
        summonerObject = GameObject.Find("summoner");
        
        gameOverScreen = GameObject.FindGameObjectWithTag("DeathPanel");
        if (gameOverScreen)
        {
            Debug.Log("Game Over Screen" + gameOverScreen);
            gameOverScreen.SetActive(false);
        }
        
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

    public void UpdateNearMissText()
    {
        nearMisses++;
        nearMissText.text = $"Near Misses: {nearMisses}";
    }

    public void EndGame()
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
        pinMovementScript.unfreeze_rotation();
    }

    public void RestartGame()
    {
        // Start Restart
        gameOver = false;
        gameOverScreen.SetActive(false);
        pinMovementScript.freeze_reset_rotation();
        
        // Reset Score Values
        score = 0;
        UpdateScoreText();
        nearMisses = -1;
        UpdateNearMissText();
        
        // Reset Time
        timePassed = 0f;
        
        // Reset Game Objects
        spawnBallScript.ResetGame();
    }

    public void PlayCollisionSound()
    {
        audioSource.Play();
    }
}
