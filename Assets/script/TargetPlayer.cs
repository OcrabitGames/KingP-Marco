using System;
using System.Collections;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    public Transform target;
    private Scoreboard _scoreboardScript;
    public ParticleSystem glowingParticles;
    
    // Attributes
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float chargeTime = 1f;
    public float attackTime = 3f;
    public int timesShot = -1;
    
    private Rigidbody2D rb_ball;

    private bool attack_on = false;
    private Vector3 movement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb_ball = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        _scoreboardScript = target.GetComponent<Scoreboard>();
        glowingParticles = GetComponentInChildren<ParticleSystem>();
        BallAttack();
    }
    
    // Launch at ball
    private void BallAttack()
    {
        if (target && !_scoreboardScript.gameOver)
        {
            if (attack_on)
            {
                // Do the calculations for the trajectory and movement
                Vector3 targetTrajectory = (transform.position - target.position).normalized;
                movement = targetTrajectory * speed;
                
                // Set velocity to the calculated movement path and speed
                rb_ball.linearVelocity = -movement;
                
                // Increment Score
                timesShot++;

                StartCoroutine(AttackSequence());
            }
            else
            {
                // Pause movement || Technically shouldn't matter?
                movement = Vector3.zero;
                
                // start particle animation for the chargeTime and then call this again
                StartCoroutine(ChargeSequence());
            }
            
            // Add score to player at the end of each shot
            if (timesShot > 0)
            {
                _scoreboardScript.score += 1;
                _scoreboardScript.UpdateScoreText();
            }
        }
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        // Rotate ball if it is attacking || Dumb Ik
        if (!_scoreboardScript.gameOver && attack_on)
        {
            rb_ball.MoveRotation(rb_ball.rotation + rotationSpeed * Time.fixedDeltaTime);
        }
    }
    
    // Log Collisions because why not
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collided with {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Player"))
        {
            _scoreboardScript.EndGame();
        }
    }

    private IEnumerator ChargeSequence()
    {
        // Freeze Rotation
        rb_ball.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        // Wait for ChargeTime
        yield return new WaitForSeconds(chargeTime);

        // Set the attack to happen
        attack_on = true;
        
        // Unfreeze Rotation
        rb_ball.constraints = RigidbodyConstraints2D.None;


        // Call Attack Method
        BallAttack();
    }

    private IEnumerator AttackSequence()
    {
        // Wait for AttackTime
        yield return new WaitForSeconds(attackTime);
        
        // Turn off attack
        attack_on = false;
        
        // Call Attack Method
        BallAttack();
    }
}
