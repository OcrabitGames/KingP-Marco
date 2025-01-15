using UnityEngine;
using UnityEngine.UIElements;

public class spawn_balls : MonoBehaviour
{
    public int round = 0;
    public float round_timer = 30f;
    
    public GameObject[] ball_prefabs;
    public Transform[] spawn_points;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        round_timer -= Time.deltaTime;
        if (round_timer <= 0)
        {
            round += 1;
            SpawnBall();
            round_timer = 30f;
        }
    }

    void SpawnBall()
    {
        int rand_point = Random.Range(0, spawn_points.Length);
        int rand_ball = Random.Range(0, ball_prefabs.Length);
        Instantiate(ball_prefabs[rand_ball], spawn_points[rand_point].position, spawn_points[rand_point].rotation);
    }
}
