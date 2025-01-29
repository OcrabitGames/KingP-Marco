using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float minX; 
    public float maxX; 
    public float minY; 
    public float maxY; 
    public float minSpeed; 
    public float maxSpeed;
    Vector2 _targetPosition; 
    public int secondsToMaxSpeed;
    
    public GameObject target; 
    public float minLaunchSpeed; 
    public float maxLaunchSpeed;
    public float minTimeToLaunch; 
    public float maxTimeToLaunch; 
    public float cooldown; 
    public bool launching;
    public float launchDuration;
    public float timeLastLaunch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // secondsToMaxSpeed = 30;
        // minSpeed = 0.01f;
        // maxSpeed = 0.075f;
        _targetPosition = RandomPosition();
    }

    // Update is called once per frame
    void Update() {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        if (OnCooldown() == false) {
            if (launching) {
                float currentLaunchTime = Time.time - timeLastLaunch;
                if (currentLaunchTime > launchDuration) {
                    StartCooldown();
                }
            }
            else {
                Launch();
            }
        }

        currentPosition = transform.position;
        float distance = Vector2.Distance((Vector2)transform.position, _targetPosition);
        if (distance > 0.1f) {
            float currentSpeed;
            if (launching == true) {
                currentSpeed = Mathf.Lerp(minLaunchSpeed, maxLaunchSpeed, GetDifficultyPercentage());
            } else {
                currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercentage ());
            }
            
            currentSpeed = currentSpeed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, _targetPosition, currentSpeed);
            transform.position = newPosition;
        } else {
            if (launching == true) {
                StartCooldown();
            }
            _targetPosition = RandomPosition();
        }
    }

    public void Launch()
    {
        _targetPosition = target.transform.position;
        if (launching == false)
        {
            timeLastLaunch = Time.time;
            launching = true;
        }
    }
    
    public bool OnCooldown () {
        bool onCooldown = true;
        float timeSinceLastLaunch = (Time.time - timeLastLaunch);
        
        if (timeSinceLastLaunch > cooldown) {
            onCooldown = false; 
        }
        return onCooldown;
    }

    void StartCooldown()
    {
        launching = false;
        timeLastLaunch = Time.time;
    }
    
    private float GetDifficultyPercentage() {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxSpeed);
    }
    
    Vector2 RandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Debug.Log("rx: " + randomX + "ry:" + randomY) ;
        Vector2 v = new Vector2(randomX, randomY);
        return v;
    }
    
    
}
