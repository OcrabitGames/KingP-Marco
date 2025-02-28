using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationVelocity = 5f;
    
    // Dash Stuff
    public float dashCooldown = 3f;
    public float _dashCooldown;
    public bool isDashing = false;
    private Vector3 _dashDirection;
    public float dashDuration = 0.2f;
    private float _dashDuration;
    public float dashSpeed = 20f;
    
    // Invincibility Stuff
    public float invincibilityCooldown = 3f;
    public float _invincibilityCooldown;
    public bool isInvincible = false;
    public float invincibilityDuration = 1.5f;
    private float _invincibilityDuration;
    
    // Dash UI
    public GameObject dashCooldownOverlay;
    public TextMeshProUGUI dashCooldownText;
    
    // Invincibility UI
    public GameObject invincibilityCooldownOverlay;
    public TextMeshProUGUI invincibilityCooldownText;
    
    private Rigidbody2D _rb;
    private Scoreboard _scoreboard;
    private Camera cam;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        
        // Dash
        dashCooldownText = GameObject.Find("Canvas/Dash/DashOff/counter").GetComponent<TextMeshProUGUI>(); 
        dashCooldownOverlay = GameObject.Find("Canvas/Dash/DashOff"); // Dash
        
        // Invincibility
        invincibilityCooldownText = GameObject.Find("Canvas/Invincibility/InvincibilityOff/counter").GetComponent<TextMeshProUGUI>(); 
        invincibilityCooldownOverlay = GameObject.Find("Canvas/Invincibility/InvincibilityOff");
        
        // Set values
        _dashCooldown = dashCooldown;
        _dashDuration = dashDuration;
        _invincibilityCooldown = invincibilityCooldown;
        _invincibilityDuration = invincibilityDuration;
        
        _rb = GetComponent<Rigidbody2D>();
        _scoreboard = GetComponent<Scoreboard>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // End early if gameOver
        if (_scoreboard.gameOver)
        {
            var pressedSpace = Input.GetKey(KeyCode.Space);
            if (pressedSpace) _scoreboard.RestartGame();
            return;
        }
        
        // Rotation Keys
        var rotateLeft = Input.GetKey(KeyCode.U);
        var rotateRight = Input.GetKey(KeyCode.I);

        // Movement Keys
        // var moveHorizontal = Input.GetAxis("Horizontal");
        // var moveVertical = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        
        Vector3 mousePosG = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 movement = (new Vector3(mousePosG.x, mousePosG.y, 0) - transform.position).normalized;
        if (movement.sqrMagnitude < 0.1f)
        {
            movement = Vector2.zero;
        }
        
        
        _rb.MovePosition(transform.position + movement * (speed * Time.fixedDeltaTime));
        
        // Invincibility
        var invinceKey = Input.GetKey(KeyCode.M);
        if (invinceKey && !isInvincible && _invincibilityCooldown <= 0f)
        {
            Debug.Log("Start Invincibility");
            // Start Invincible
            isInvincible = true;
            
            // Activate Cooldown UI
            invincibilityCooldownOverlay.SetActive(true);
            
            // Initialize Cooldown
            _invincibilityDuration = invincibilityDuration;
            _invincibilityCooldown = invincibilityCooldown + invincibilityDuration;
        }
        else if (isInvincible)
        {
            if (_invincibilityDuration > 0)
            {
                _invincibilityDuration -= Time.deltaTime;
            } else {
                // End Invincibility
                isInvincible = false;
                _invincibilityDuration = invincibilityDuration; 
            }
        }
        
        if (_invincibilityCooldown > 0)
        {
            _invincibilityCooldown -= Time.fixedDeltaTime;
            invincibilityCooldownText.text = _invincibilityCooldown.ToString("F0");
        } else {
            invincibilityCooldownOverlay.SetActive(false);
        }
            
        
        // Implement Dash Feature
        var dashKey = Input.GetKey(KeyCode.Y);
        if (dashKey && !isDashing && _dashCooldown <= 0f) {
            // Start Dash
            isDashing = true;
            
            // Activate Cooldown UI
            dashCooldownOverlay.SetActive(true);
            
            // Initialize direction and cooldown
            _dashDuration = dashDuration;
            _dashDirection = movement.normalized;
            _dashCooldown = dashCooldown + dashDuration;
        }
        if (isDashing) {
            if (_dashDuration > 0) {
                _dashDuration -= Time.deltaTime;
                _rb.MovePosition(transform.position + _dashDirection * (dashSpeed * Time.fixedDeltaTime));
            } else { 
                // End Dash
                isDashing = false; // Reset Dash Motion and Duration
                
                // Reset direction and cooldown
                _dashDuration = dashDuration; 
                _dashDirection = Vector3.zero;
            }
        } 
        
        if (_dashCooldown > 0)
        {
            _dashCooldown -= Time.fixedDeltaTime;
            dashCooldownText.text = _dashCooldown.ToString("F0");
        } else {
            dashCooldownOverlay.SetActive(false);
        }
        
        if (rotateLeft)
        {
            _rb.angularVelocity = _rb.angularVelocity + rotationVelocity;
            //_rb.MoveRotation(_rb.rotation + rotationSpeed*Time.fixedDeltaTime);
        }
        else if (rotateRight)
        {
            _rb.angularVelocity = _rb.angularVelocity - rotationVelocity;
            //_rb.MoveRotation(_rb.rotation + -rotationSpeed*Time.fixedDeltaTime);
        }
    }

    public void unfreeze_rotation()
    {
        _rb.freezeRotation = false;
    }
    
    public void freeze_reset_rotation()
    {
        _rb.rotation = 0f;
        _rb.freezeRotation = true;
    }

    public bool CheckInvincibility()
    {
        return isInvincible;
    }
}
