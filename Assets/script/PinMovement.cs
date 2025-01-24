using UnityEngine;

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
    
    private Rigidbody2D _rb;
    private Scoreboard _scoreboard;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _scoreboard = GetComponent<Scoreboard>();
        
        // Set values
        _dashCooldown = dashCooldown;
        _dashDuration = dashDuration;
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
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        
        // Do Regular Movement
        if (_dashCooldown > 0) _dashCooldown -= Time.fixedDeltaTime;
        _rb.MovePosition(transform.position + movement * (speed * Time.fixedDeltaTime));
        
        // Implement Dash Feature
        var dashKey = Input.GetKey(KeyCode.Y);
        if (dashKey && !isDashing && _dashCooldown <= 0f) {
            isDashing = true;
            _dashDuration = dashDuration;
            _dashDirection = movement.normalized;
            _dashCooldown = dashCooldown + dashDuration;
        }
        if (isDashing) {
            if (_dashDuration > 0) {
                _dashDuration -= Time.deltaTime;
                _rb.MovePosition(transform.position + _dashDirection * (dashSpeed * Time.fixedDeltaTime));
            } else { 
                isDashing = false; // Reset Dash Motion and Duration
                _dashDuration = dashDuration; 
                _dashDirection = Vector3.zero;
            }
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
}
