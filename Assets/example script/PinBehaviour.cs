using Unity.VisualScripting;
using UnityEngine;

public class PinBehaviour : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector2 newPosition; 
    public Vector3 mousePosG;
    Camera cam;

    // Update is called once per frame
    void Update()
    {
        mousePosG = cam.ScreenToWorldPoint (Input.mousePosition);
        newPosition = Vector2.MoveTowards(transform.position, mousePosG, speed * Time.fixedDeltaTime);
        transform.position = newPosition;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collided = collision.gameObject.tag;
        Debug.Log("Collided with " + collided);
        if (collided == "Ball" || collided == "Wall")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
        }
    }
}
