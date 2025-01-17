using UnityEngine;
using UnityEngine.UIElements;

public class spawn_balls : MonoBehaviour
{
    public float roundTimer = 30f;
    private float _timeLeft;
    
    public GameObject[] ball_prefabs;
    public Transform[] spawn_points;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _timeLeft = roundTimer;
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

    void SpawnBall()
    {
        int rand_point = Random.Range(0, spawn_points.Length);
        int rand_ball = Random.Range(0, ball_prefabs.Length);
        Instantiate(ball_prefabs[rand_ball], spawn_points[rand_point].position, spawn_points[rand_point].rotation);
    }
}
