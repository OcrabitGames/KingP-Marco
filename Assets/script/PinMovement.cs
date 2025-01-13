using UnityEngine;

public class PinMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D _rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        
        _rb.MovePosition(transform.position + movement * (speed * Time.fixedDeltaTime));
    }
}
