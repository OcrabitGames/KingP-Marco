using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void goToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
}
