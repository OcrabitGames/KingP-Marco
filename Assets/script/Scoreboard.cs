using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
