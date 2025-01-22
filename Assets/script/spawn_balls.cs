using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class spawn_balls : MonoBehaviour
{
    public float roundTimer = 30f;
    private float _timeLeft;
    
    public GameObject[] ball_prefabs;
    public Transform[] spawn_points;
    public List<GameObject> balls = new List<GameObject>();
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    public void SpawnBall()
    {
        int randPoint = Random.Range(0, spawn_points.Length);
        int randBall = Random.Range(0, ball_prefabs.Length);
        GameObject newBall = Instantiate(ball_prefabs[randBall], spawn_points[randPoint].position, spawn_points[randPoint].rotation);
        balls.Add(newBall);
    }

    public void ClearBalls()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            Destroy(balls[i]);
        }
        balls.Clear();
    }
}
