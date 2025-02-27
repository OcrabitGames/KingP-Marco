using System.Collections.Generic;
using UnityEngine;

public class spawn_balls : MonoBehaviour
{
    public float roundTimer = 30f;
    private float _timeLeft;
    
    public GameObject[] ball_prefabs;
    public Transform[] spawn_points;
    public List<GameObject> balls = new List<GameObject>();
    
    public GameObject targetObject;
    public Pins pinsDB;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPin();
        _timeLeft = roundTimer;
        int randPoint = Random.Range(0, spawn_points.Length);
        int randBall = Random.Range(0, ball_prefabs.Length);
        GameObject newBall = Instantiate(ball_prefabs[randBall], spawn_points[randPoint].position, spawn_points[randPoint].rotation);
        balls.Add(newBall);
    }

    // Update is called once per frame
    void Update()
    {
        
        _timeLeft -= Time.deltaTime;
        if (_timeLeft <= 0)
        {
            SpawnBall();
            _timeLeft = roundTimer;
        }
    }

    private void SpawnBall()
    {
        int randPoint = Random.Range(0, spawn_points.Length);
        int randBall = Random.Range(0, ball_prefabs.Length);
        GameObject newBall = Instantiate(ball_prefabs[randBall], spawn_points[randPoint].position, spawn_points[randPoint].rotation);
        balls.Add(newBall);
    }

    private void ClearBalls()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            Destroy(balls[i]);
        }
        balls.Clear();
    }

    public void ResetGame()
    {
        // Reset Ball spawn clock to round timer
        _timeLeft = roundTimer;
        
        // Reset Ball States
        ClearBalls();
        SpawnBall();
    }
    
    void SpawnPin() {
        Debug.Log("sel" +CharacterManager.selection);
        targetObject = Instantiate(pinsDB.GetPin(CharacterManager.selection).prefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }
    
}
