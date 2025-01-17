using UnityEngine;

public class PinMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationVelocity = 5f;
    private Rigidbody2D _rb;
    private Scoreboard _scoreboard;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            ;
        
        // Rotation Keys
        var rotateLeft = Input.GetKey(KeyCode.U);
        var rotateRight = Input.GetKey(KeyCode.I);

        // Movement Keys
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        _rb.MovePosition(transform.position + movement * (speed * Time.fixedDeltaTime));

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
